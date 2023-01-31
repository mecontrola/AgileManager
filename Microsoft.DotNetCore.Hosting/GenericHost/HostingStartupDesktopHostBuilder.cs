using Microsoft.DotNetCore.Hosting.Infrastructure;
using Microsoft.DotNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.DotNetCore.Hosting
{
    internal sealed class HostingStartupDesktopHostBuilder : IDesktopHostBuilder, ISupportsStartup
    {
        private readonly GenericDesktopHostBuilder builder;
        private Action<DesktopHostBuilderContext, IConfigurationBuilder> configureConfiguration;
        private Action<DesktopHostBuilderContext, IServiceCollection> configureServices;

        public HostingStartupDesktopHostBuilder(GenericDesktopHostBuilder builder)
            => this.builder = builder;

        public IDesktopHost Build()
        {
            throw new NotSupportedException($"Building this implementation of {nameof(IDesktopHostBuilder)} is not supported.");
        }

        public IDesktopHostBuilder ConfigureAppConfiguration(Action<DesktopHostBuilderContext, IConfigurationBuilder> configureConfiguration)
        {
            this.configureConfiguration += configureConfiguration;
            return this;
        }

        public IDesktopHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
        {
            return ConfigureServices((context, services) => configureServices(services));
        }

        public IDesktopHostBuilder ConfigureServices(Action<DesktopHostBuilderContext, IServiceCollection> configureServices)
        {
            this.configureServices += configureServices;
            return this;
        }

        public string GetSetting(string key)
            => builder.GetSetting(key);

        public IDesktopHostBuilder UseSetting(string key, string value)
        {
            builder.UseSetting(key, value);
            return this;
        }

        public void ConfigureServices(DesktopHostBuilderContext context, IServiceCollection services)
            => configureServices?.Invoke(context, services);

        public void ConfigureAppConfiguration(DesktopHostBuilderContext context, IConfigurationBuilder builder)
            => configureConfiguration?.Invoke(context, builder);

        public IDesktopHostBuilder UseDefaultServiceProvider(Action<DesktopHostBuilderContext, ServiceProviderOptions> configure)
            => builder.UseDefaultServiceProvider(configure);

        public IDesktopHostBuilder Configure(Action<IApplicationBuilder> configure)
            => builder.Configure(configure);

        public IDesktopHostBuilder Configure(Action<DesktopHostBuilderContext, IApplicationBuilder> configure)
            => builder.Configure(configure);

        public IDesktopHostBuilder UseStartup([DynamicallyAccessedMembers(StartupLinkerOptions.Accessibility)] Type startupType)
            => builder.UseStartup(startupType);

        // Note: This method isn't 100% compatible with trimming. It is possible for the factory to return a derived type from TStartup.
        // RequiresUnreferencedCode isn't on this method because the majority of people won't do that.
        public IDesktopHostBuilder UseStartup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TStartup>(Func<DesktopHostBuilderContext, TStartup> startupFactory)
            => builder.UseStartup(startupFactory);
    }
}