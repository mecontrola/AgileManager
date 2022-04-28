using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace Stefanini.ViaReport.Updater
{
    public partial class App : Application
    {
        private static readonly string CONFIGURATION_FILENAME = "appsettings.json";
        private static readonly string CONFIGURATION_FILENAME_DEVELOPMENT = "appsettings.Development.json";

        private readonly IServiceProvider serviceProvider;

        public App()
        {
            serviceProvider = BuildServiceColletion().BuildServiceProvider();
        }

        private static IServiceCollection BuildServiceColletion()
        {
            var configuration = BuildConfiguration();
            var services = new ServiceCollection();
            services.AddSingleton(configuration);

            var startup = new Startup(configuration);

            startup.ConfigureServices(services);

            return services;
        }

        private static IConfiguration BuildConfiguration()
            => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                         .AddJsonFile(CONFIGURATION_FILENAME, optional: true, reloadOnChange: true)
                                         .AddJsonFile(CONFIGURATION_FILENAME_DEVELOPMENT, optional: true, reloadOnChange: true)
                                         .Build();

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}