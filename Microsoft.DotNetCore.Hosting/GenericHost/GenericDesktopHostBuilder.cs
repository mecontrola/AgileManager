using Microsoft.DotNetCore.Hosting.Infrastructure;
using Microsoft.DotNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Microsoft.DotNetCore.Hosting
{
    internal sealed class GenericDesktopHostBuilder : IDesktopHostBuilder, ISupportsStartup
    {
        private readonly IHostBuilder builder;
        private readonly IConfiguration config;
        private object startupObject;
        private readonly object startupKey = new();

        private AggregateException hostingStartupErrors;
        private HostingStartupDesktopHostBuilder hostingStartupDesktopHostBuilder;

        public GenericDesktopHostBuilder(IHostBuilder builder, DesktopHostBuilderOptions options)
        {
            this.builder = builder;

            var configBuilder = new ConfigurationBuilder().AddInMemoryCollection();

            if (!options.SuppressEnvironmentConfiguration)
                configBuilder.AddEnvironmentVariables(prefix: "DOTNETCORE_");

            config = configBuilder.Build();

            this.builder.ConfigureHostConfiguration(config =>
            {
                config.AddConfiguration(this.config);

                // We do this super early but still late enough that we can process the configuration
                // wired up by calls to UseSetting
                ExecuteHostingStartups();
            });

            // IHostingStartup needs to be executed before any direct methods on the builder
            // so register these callbacks first
            builder.ConfigureAppConfiguration((context, configurationBuilder) =>
            {
                if (hostingStartupDesktopHostBuilder != null)
                {
                    var desktopHostContext = GetDesktopHostBuilderContext(context);
                    hostingStartupDesktopHostBuilder.ConfigureAppConfiguration(desktopHostContext, configurationBuilder);
                }
            });

            builder.ConfigureServices((context, services) =>
            {
                var desktopHostContext = GetDesktopHostBuilderContext(context);
                var desktopHostOptions = (DesktopHostOptions)context.Properties[typeof(DesktopHostOptions)];

                // Add the IHostingEnvironment and IApplicationLifetime from Microsoft.AspNetCore.Hosting
                services.AddSingleton(desktopHostContext.HostingEnvironment);

                //services.Configure<GenericDesktopHostServiceOptions>(options =>
                //{
                //    // Set the options
                //    options.DesktopHostOptions = desktopHostOptions;
                //    // Store and forward any startup errors
                //    options.HostingStartupExceptions = hostingStartupErrors;
                //});

                // IMPORTANT: This needs to run *before* direct calls on the builder (like UseStartup)
                hostingStartupDesktopHostBuilder?.ConfigureServices(desktopHostContext, services);

                // Support UseStartup(assemblyName)
                if (!string.IsNullOrEmpty(desktopHostOptions.StartupAssembly))
                    ScanAssemblyAndRegisterStartup(context, services, desktopHostContext, desktopHostOptions);
            });
        }

        [UnconditionalSuppressMessage("Trimmer", "IL2072", Justification = "Finding startup type in assembly requires unreferenced code. Surfaced to user in UseStartup(assemblyName).")]
        private void ScanAssemblyAndRegisterStartup(HostBuilderContext context, IServiceCollection services, DesktopHostBuilderContext desktopHostContext, DesktopHostOptions desktopHostOptions)
        {
            try
            {
                var startupType = StartupLoader.FindStartupType(desktopHostOptions.StartupAssembly!, desktopHostContext.HostingEnvironment.EnvironmentName);
                UseStartup(startupType, context, services);
            }
            catch (Exception ex) when (desktopHostOptions.CaptureStartupErrors)
            {
                var capture = ExceptionDispatchInfo.Capture(ex);

                //services.Configure<GenericDesktopHostServiceOptions>(options =>
                //{
                //    options.ConfigureApplication = app =>
                //    {
                //        // Throw if there was any errors initializing startup
                //        capture.Throw();
                //    };
                //});
            }
        }

        private void ExecuteHostingStartups()
        {
            var desktopHostOptions = new DesktopHostOptions(config);
            
            if (desktopHostOptions.PreventHostingStartup)
                return;
            
            var exceptions = new List<Exception>();
            var processed = new HashSet<Assembly>();
            
            hostingStartupDesktopHostBuilder = new HostingStartupDesktopHostBuilder(this);
            
            // Execute the hosting startup assemblies
            foreach (var assemblyName in desktopHostOptions.GetFinalHostingStartupAssemblies())
            {
                try
                {
                    var assembly = Assembly.Load(new AssemblyName(assemblyName));
            
                    if (!processed.Add(assembly))
                        // Already processed, skip it
                        continue;
            
                    foreach (var attribute in assembly.GetCustomAttributes<HostingStartupAttribute>())
                    {
                        var hostingStartup = (IHostingStartup)Activator.CreateInstance(attribute.HostingStartupType)!;
                        hostingStartup.Configure(hostingStartupDesktopHostBuilder);
                    }
                }
                catch (Exception ex)
                {
                    // Capture any errors that happen during startup
                    exceptions.Add(new InvalidOperationException($"Startup assembly {assemblyName} failed to execute. See the inner exception for more details.", ex));
                }
            }
            
            if (exceptions.Count > 0)
                hostingStartupErrors = new AggregateException(exceptions);
        }

        public IDesktopHost Build()
            => throw new NotSupportedException($"Building this implementation of {nameof(IDesktopHostBuilder)} is not supported.");

        public IDesktopHostBuilder ConfigureAppConfiguration(Action<DesktopHostBuilderContext, IConfigurationBuilder> configureDelegate)
        {
            builder.ConfigureAppConfiguration((context, builder) =>
            {
                var desktopHostBuilderContext = GetDesktopHostBuilderContext(context);
                configureDelegate(desktopHostBuilderContext, builder);
            });

            return this;
        }

        public IDesktopHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
            => ConfigureServices((context, services) => configureServices(services));

        public IDesktopHostBuilder ConfigureServices(Action<DesktopHostBuilderContext, IServiceCollection> configureServices)
        {
            builder.ConfigureServices((context, builder) =>
            {
                var desktopHostBuilderContext = GetDesktopHostBuilderContext(context);
                configureServices(desktopHostBuilderContext, builder);
            });

            return this;
        }

        public IDesktopHostBuilder UseDefaultServiceProvider(Action<DesktopHostBuilderContext, ServiceProviderOptions> configure)
        {
            builder.UseServiceProviderFactory(context =>
            {
                var desktopHostBuilderContext = GetDesktopHostBuilderContext(context);
                var options = new ServiceProviderOptions();
                configure(desktopHostBuilderContext, options);
                return new DefaultServiceProviderFactory(options);
            });

            return this;
        }

        public IDesktopHostBuilder UseStartup([DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType)
        {
            var startupAssemblyName = startupType.Assembly.GetName().Name;

            UseSetting(DesktopHostDefaults.ApplicationKey, startupAssemblyName);

            // UseStartup can be called multiple times. Only run the last one.
            startupObject = startupType;

            var state = new UseStartupState(startupType);

            builder.ConfigureServices((context, services) =>
            {
                // Run this delegate if the startup type matches
                if (object.ReferenceEquals(startupObject, state.StartupType))
                    UseStartup(state.StartupType, context, services);
            });

            return this;
        }
        //
        // Note: This method isn't 100% compatible with trimming. It is possible for the factory to return a derived type from TStartup.
        // RequiresUnreferencedCode isn't on this method because the majority of people won't do that.
        public IDesktopHostBuilder UseStartup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TStartup>(Func<DesktopHostBuilderContext, TStartup> startupFactory)
        {
            var startupAssemblyName = startupFactory.GetMethodInfo().DeclaringType!.Assembly.GetName().Name;

            UseSetting(DesktopHostDefaults.ApplicationKey, startupAssemblyName);

            // Clear the startup type
            startupObject = startupFactory;

            builder.ConfigureServices(ConfigureStartup);

            [UnconditionalSuppressMessage("Trimmer", "IL2072", Justification = "Startup type created by factory can't be determined statically.")]
            void ConfigureStartup(HostBuilderContext context, IServiceCollection services)
            {
                // UseStartup can be called multiple times. Only run the last one.
                if (object.ReferenceEquals(startupObject, startupFactory))
                {
                    var desktopHostBuilderContext = GetDesktopHostBuilderContext(context);
                    var instance = startupFactory(desktopHostBuilderContext) ?? throw new InvalidOperationException("The specified factory returned null startup instance.");
                    UseStartup(instance.GetType(), context, services, instance);
                }
            }

            return this;
        }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2006:UnrecognizedReflectionPattern", Justification = "We need to call a generic method on IHostBuilder.")]
        private void UseStartup([DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType, HostBuilderContext context, IServiceCollection services, object instance = null)
        {
            var desktopHostBuilderContext = GetDesktopHostBuilderContext(context);
            var desktopHostOptions = (DesktopHostOptions)context.Properties[typeof(DesktopHostOptions)];

            ExceptionDispatchInfo startupError = null;
            ConfigureBuilder configureBuilder = null;

            try
            {
                // We cannot support methods that return IServiceProvider as that is terminal and we need ConfigureServices to compose
                if (typeof(IStartup).IsAssignableFrom(startupType))
                    throw new NotSupportedException($"{typeof(IStartup)} isn't supported");

                if (StartupLoader.HasConfigureServicesIServiceProviderDelegate(startupType, context.HostingEnvironment.EnvironmentName))
                    throw new NotSupportedException($"ConfigureServices returning an {typeof(IServiceProvider)} isn't supported.");

                instance ??= ActivatorUtilities.CreateInstance(new HostServiceProvider(desktopHostBuilderContext), startupType);
                context.Properties[startupKey] = instance;

                // Startup.ConfigureServices
                var configureServicesBuilder = StartupLoader.FindConfigureServicesDelegate(startupType, context.HostingEnvironment.EnvironmentName);
                var configureServices = configureServicesBuilder.Build(instance);

                configureServices(services);

                // REVIEW: We're doing this in the callback so that we have access to the hosting environment
                // Startup.ConfigureContainer
                var configureContainerBuilder = StartupLoader.FindConfigureContainerDelegate(startupType, context.HostingEnvironment.EnvironmentName);
                if (configureContainerBuilder.MethodInfo != null)
                {
                    var containerType = configureContainerBuilder.GetContainerType();
                    // Store the builder in the property bag
                    builder.Properties[typeof(ConfigureContainerBuilder)] = configureContainerBuilder;

                    var actionType = typeof(Action<,>).MakeGenericType(typeof(HostBuilderContext), containerType);

                    // Get the private ConfigureContainer method on this type then close over the container type
                    var configureCallback = typeof(GenericDesktopHostBuilder).GetMethod(nameof(ConfigureContainerImpl), BindingFlags.NonPublic | BindingFlags.Instance)!
                                                                             .MakeGenericMethod(containerType)
                                                                             .CreateDelegate(actionType, this);

                    // builder.ConfigureContainer<T>(ConfigureContainer);
                    typeof(IHostBuilder).GetMethod(nameof(IHostBuilder.ConfigureContainer))!
                                        .MakeGenericMethod(containerType)
                                        .InvokeWithoutWrappingExceptions(builder, new object[] { configureCallback });
                }

                // Resolve Configure after calling ConfigureServices and ConfigureContainer
                configureBuilder = StartupLoader.FindConfigureDelegate(startupType, context.HostingEnvironment.EnvironmentName);
            }
            catch (Exception ex) when (desktopHostOptions.CaptureStartupErrors)
            {
                startupError = ExceptionDispatchInfo.Capture(ex);
            }

            // Startup.Configure
            //services.Configure<GenericDesktopHostServiceOptions>(options =>
            //{
            //    options.ConfigureApplication = app =>
            //    {
            //        // Throw if there was any errors initializing startup
            //        startupError?.Throw();
            //
            //        // Execute Startup.Configure
            //        if (instance != null && configureBuilder != null)
            //            configureBuilder.Build(instance)(app);
            //    };
            //});
        }

        private void ConfigureContainerImpl<TContainer>(HostBuilderContext context, TContainer container) where TContainer : notnull
        {
            var instance = context.Properties[startupKey];
            var builder = (ConfigureContainerBuilder)context.Properties[typeof(ConfigureContainerBuilder)];
            builder.Build(instance)(container);
        }

        public IDesktopHostBuilder Configure(Action<IApplicationBuilder> configure)
        {
            var startupAssemblyName = configure.GetMethodInfo().DeclaringType!.Assembly.GetName().Name!;

            UseSetting(DesktopHostDefaults.ApplicationKey, startupAssemblyName);

            // Clear the startup type
            startupObject = configure;
            
            builder.ConfigureServices((context, services) =>
            {
                if (object.ReferenceEquals(startupObject, configure))
                {
                    //services.Configure<GenericDesktopHostServiceOptions>(options =>
                    //{
                    //    options.ConfigureApplication = app => configure(app);
                    //});
                }
            });

            return this;
        }

        public IDesktopHostBuilder Configure(Action<DesktopHostBuilderContext, IApplicationBuilder> configure)
        {
            var startupAssemblyName = configure.GetMethodInfo().DeclaringType!.Assembly.GetName().Name!;

            UseSetting(DesktopHostDefaults.ApplicationKey, startupAssemblyName);

            // Clear the startup type
            startupObject = configure;

            builder.ConfigureServices((context, services) =>
            {
                if (object.ReferenceEquals(startupObject, configure))
                {
                    //services.Configure<GenericDesktopHostServiceOptions>(options =>
                    //{
                    //    var desktopHostBuilderContext = GetDesktopHostBuilderContext(context);
                    //    options.ConfigureApplication = app => configure(desktopHostBuilderContext, app);
                    //});
                }
            });

            return this;
        }

        private DesktopHostBuilderContext GetDesktopHostBuilderContext(HostBuilderContext context)
        {
            if (!context.Properties.TryGetValue(typeof(DesktopHostBuilderContext), out var contextVal))
            {
                // Use config as a fallback for DesktopHostOptions in case the chained source was removed from the hosting IConfigurationBuilder.
                var options = new DesktopHostOptions(context.Configuration, fallbackConfiguration: config, environment: context.HostingEnvironment);
                var desktopHostBuilderContext = new DesktopHostBuilderContext
                {
                    Configuration = context.Configuration,
                    HostingEnvironment = new HostingEnvironment(),
                };
                desktopHostBuilderContext.HostingEnvironment.Initialize(context.HostingEnvironment.ContentRootPath, options, baseEnvironment: context.HostingEnvironment);
                context.Properties[typeof(DesktopHostBuilderContext)] = desktopHostBuilderContext;
                context.Properties[typeof(DesktopHostOptions)] = options;
                return desktopHostBuilderContext;
            }

            // Refresh config, it's periodically updated/replaced
            var webHostContext = (DesktopHostBuilderContext)contextVal;
            webHostContext.Configuration = context.Configuration;
            return webHostContext;
        }

        public string GetSetting(string key)
            => config[key] ?? string.Empty;

        public IDesktopHostBuilder UseSetting(string key, string value)
        {
            config[key] = value;
            return this;
        }
        
        // This exists just so that we can use ActivatorUtilities.CreateInstance on the Startup class
        private sealed class HostServiceProvider : IServiceProvider
        {
            private readonly DesktopHostBuilderContext context;

            public HostServiceProvider(DesktopHostBuilderContext context)
                => this.context = context;

            public object GetService(Type serviceType)
            {
                // The implementation of the HostingEnvironment supports both interfaces
                if (serviceType == typeof(IHostEnvironment))
                    return context.HostingEnvironment;

                if (serviceType == typeof(IConfiguration))
                    return context.Configuration;

                return null;
            }
        }
    }
}