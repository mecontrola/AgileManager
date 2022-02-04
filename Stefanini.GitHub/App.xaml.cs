using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace Stefanini.GitHub
{
    public partial class App : Application
    {
        private static readonly string CONFIGURATION_FILENAME = "appsettings.json";

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
                                         .AddJsonFile(CONFIGURATION_FILENAME, optional: false, reloadOnChange: true)
                                         .Build();

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
            mainWindow.Show();
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
        }
    }
}