using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Windows;

namespace MeControla.AgileManager
{
    sealed partial class App : Application
    {
        private readonly IHost host;

        public App()
            => host = CreateHostBuilder().Build();

        public static IHostBuilder CreateHostBuilder()
            => Host.CreateDefaultBuilder()
                   .ConfigureServices(ConfigureServices())
                   .UseSerilog(ConfigureSerilog(), writeToProviders: true);

        private static Action<HostBuilderContext, LoggerConfiguration> ConfigureSerilog()
            => (context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration);

        private static Action<HostBuilderContext, IServiceCollection> ConfigureServices()
            => (context, services) => new Startup(context.Configuration).ConfigureServices(services);

        protected override void OnStartup(StartupEventArgs e)
        {
            host.Start();

            var mainWindow = host.Services.GetService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await host.StopAsync();

            host.Dispose();

            base.OnExit(e);
        }
    }
}