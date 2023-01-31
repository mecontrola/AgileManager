using Microsoft.DotNetCore.Hosting.Infrastructure;
using Microsoft.DotNetCore.Hosting.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Microsoft.DotNetCore.Hosting
{
    /// <summary>
    /// Contains extensions for configuring an <see cref="IDesktopHostBuilder" />.
    /// </summary>
    public static class DesktopHostBuilderExtensions
    {
        /// <summary>
        /// Specify the startup method to be used to configure the desktop application.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="IDesktopHostBuilder"/> to configure.</param>
        /// <param name="configureApp">The delegate that configures the <see cref="IApplicationBuilder"/>.</param>
        /// <returns>The <see cref="IDesktopHostBuilder"/>.</returns>
        public static IDesktopHostBuilder Configure(this IDesktopHostBuilder hostBuilder, Action<IApplicationBuilder> configureApp)
        {
            if (configureApp == null)
                throw new ArgumentNullException(nameof(configureApp));

            // Light up the ISupportsStartup implementation
            if (hostBuilder is ISupportsStartup supportsStartup)
                return supportsStartup.Configure(configureApp);

            var startupAssemblyName = configureApp.GetMethodInfo().DeclaringType!.Assembly.GetName().Name!;

            hostBuilder.UseSetting(DesktopHostDefaults.ApplicationKey, startupAssemblyName);

            return hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IStartup>(sp =>
                {
                    return new DelegateStartup(sp.GetRequiredService<IServiceProviderFactory<IServiceCollection>>(), (app => configureApp(app)));
                });
            });
        }

        /// <summary>
        /// Specify the startup method to be used to configure the desktop application.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="IDesktopHostBuilder"/> to configure.</param>
        /// <param name="configureApp">The delegate that configures the <see cref="IApplicationBuilder"/>.</param>
        /// <returns>The <see cref="IDesktopHostBuilder"/>.</returns>
        public static IDesktopHostBuilder Configure(this IDesktopHostBuilder hostBuilder, Action<DesktopHostBuilderContext, IApplicationBuilder> configureApp)
        {
            if (configureApp == null)
                throw new ArgumentNullException(nameof(configureApp));

            // Light up the ISupportsStartup implementation
            if (hostBuilder is ISupportsStartup supportsStartup)
                return supportsStartup.Configure(configureApp);

            var startupAssemblyName = configureApp.GetMethodInfo().DeclaringType!.Assembly.GetName().Name!;

            hostBuilder.UseSetting(DesktopHostDefaults.ApplicationKey, startupAssemblyName);

            return hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IStartup>(sp =>
                {
                    return new DelegateStartup(sp.GetRequiredService<IServiceProviderFactory<IServiceCollection>>(), (app => configureApp(context, app)));
                });
            });
        }

        /// <summary>
        /// Specify a factory that creates the startup instance to be used by the desktop host.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="IDesktopHostBuilder"/> to configure.</param>
        /// <param name="startupFactory">A delegate that specifies a factory for the startup class.</param>
        /// <returns>The <see cref="IDesktopHostBuilder"/>.</returns>
        /// <remarks>When using the il linker, all public methods of <typeparamref name="TStartup"/> are preserved. This should match the Startup type directly (and not a base type).</remarks>
        public static IDesktopHostBuilder UseStartup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TStartup>(this IDesktopHostBuilder hostBuilder, Func<DesktopHostBuilderContext, TStartup> startupFactory)
            where TStartup : class
        {
            if (startupFactory == null)
                throw new ArgumentNullException(nameof(startupFactory));

            // Light up the GenericWebHostBuilder implementation
            //if (hostBuilder is ISupportsStartup supportsStartup)
            //{
            //    return supportsStartup.UseStartup(startupFactory);
            //}
            //
            //var startupAssemblyName = startupFactory.GetMethodInfo().DeclaringType!.Assembly.GetName().Name;
            //
            //hostBuilder.UseSetting(WebHostDefaults.ApplicationKey, startupAssemblyName);

            return hostBuilder.ConfigureServices((context, services) =>
            {
                //services.AddSingleton(typeof(IStartup), GetStartupInstance);
                //
                //[UnconditionalSuppressMessage("Trimmer", "IL2072", Justification = "Startup type created by factory can't be determined statically.")]
                //object GetStartupInstance(IServiceProvider serviceProvider)
                //{
                //    var instance = startupFactory(context) ?? throw new InvalidOperationException("The specified factory returned null startup instance.");
                //
                //    var hostingEnvironment = serviceProvider.GetRequiredService<IHostEnvironment>();
                //
                //    // Check if the instance implements IStartup before wrapping
                //    if (instance is IStartup startup)
                //    {
                //        return startup;
                //    }
                //
                //    return new ConventionBasedStartup(StartupLoader.LoadMethods(serviceProvider, instance.GetType(), hostingEnvironment.EnvironmentName, instance));
                //}
            });
        }

        /// <summary>
        /// Specify the startup type to be used by the desktop host.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="IDesktopHostBuilder"/> to configure.</param>
        /// <param name="startupType">The <see cref="Type"/> to be used.</param>
        /// <returns>The <see cref="IDesktopHostBuilder"/>.</returns>
        public static IDesktopHostBuilder UseStartup(this IDesktopHostBuilder hostBuilder, [DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType)
        {
            if (startupType == null)
                throw new ArgumentNullException(nameof(startupType));

            // Light up the GenericDesktopHostBuilder implementation
            if (hostBuilder is ISupportsStartup supportsStartup)
                return supportsStartup.UseStartup(startupType);
            //
            //var startupAssemblyName = startupType.Assembly.GetName().Name;
            //
            //hostBuilder.UseSetting(WebHostDefaults.ApplicationKey, startupAssemblyName);
            //
            //var state = new UseStartupState(startupType);

            return hostBuilder.ConfigureServices(services =>
            {
                //if (typeof(IStartup).IsAssignableFrom(state.StartupType))
                //{
                //    services.AddSingleton(typeof(IStartup), state.StartupType);
                //}
                //else
                //{
                //    services.AddSingleton(typeof(IStartup), sp =>
                //    {
                //        var hostingEnvironment = sp.GetRequiredService<IHostEnvironment>();
                //        return new ConventionBasedStartup(StartupLoader.LoadMethods(sp, state.StartupType, hostingEnvironment.EnvironmentName));
                //    });
                //}
            });
        }

        /// <summary>
        /// Specify the startup type to be used by the web host.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="IDesktopHostBuilder"/> to configure.</param>
        /// <typeparam name ="TStartup">The type containing the startup methods for the application.</typeparam>
        /// <returns>The <see cref="IDesktopHostBuilder"/>.</returns>
        public static IDesktopHostBuilder UseStartup<[DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] TStartup>(this IDesktopHostBuilder hostBuilder)
            where TStartup : class
            => hostBuilder.UseStartup(typeof(TStartup));
    }
}