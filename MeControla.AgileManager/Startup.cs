﻿using MeControla.AgileManager.Core.IoC;
using MeControla.AgileManager.DataStorage.Extensions;
using MeControla.AgileManager.DataStorage.IoC;
using MeControla.AgileManager.Helpers;
using MeControla.AgileManager.Updater.Core.Extensions;
using MeControla.AgileManager.Updater.Core.Helpers;
using MeControla.AgileManager.Updater.Core.Integrations.Github.Repos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeControla.AgileManager
{
    public class Startup
    {
        private const string DATABASE_CONNECTION_NAME = "DefaultConnection";

        private IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseServices(GetDatabaseConnection());

            services.AddSingleton<MainWindow>();
            services.AddSingleton<AuthenticationWindow>();

            services.AddSingleton<IUpdateToastHelper, UpdateToastHelper>();

            InjectUpdater(services);

            services.AddBusiness();
            services.AddHelpers();
            services.AddServices();
            services.AddMappers();
            services.AddIntegrations();
            services.AddRepositories();
        }

        private void InjectUpdater(IServiceCollection services)
        {
            services.AddSingleton<IRemoteVersionHelper, RemoteVersionHelper>();
            services.AddSingleton<IGitHubLastReleaseHelper, GitHubLastReleaseHelper>();
            services.AddSingleton<IReleasesLastest, ReleasesLastest>();
            services.AddSingleton(Configuration.GetUpdaterConfiguration());
        }

        private string GetDatabaseConnection()
            => Configuration.GetConnectionString(DATABASE_CONNECTION_NAME);
    }
}