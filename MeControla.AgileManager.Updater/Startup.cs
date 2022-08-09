using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MeControla.AgileManager.Updater.Core.Extensions;
using MeControla.AgileManager.Updater.Core.Helpers;
using MeControla.AgileManager.Updater.Core.Integrations.Github.Repos;
using MeControla.AgileManager.Updater.Core.Services;

namespace MeControla.AgileManager.Updater
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration.GetUpdaterConfiguration());
            services.AddSingleton<MainWindow>();

            services.TryAddSingleton<IApplicationArchitectureHelper, ApplicationArchitectureHelper>();
            services.TryAddSingleton<IDownloadFileHelper, DownloadFileHelper>();
            services.TryAddSingleton<IGitHubLastReleaseHelper, GitHubLastReleaseHelper>();
            services.TryAddSingleton<ILocalVersionHelper, LocalVersionHelper>();
            services.TryAddSingleton<IRemoteVersionHelper, RemoteVersionHelper>();
            services.TryAddSingleton<IStep01Helper, Step01Helper>();
            services.TryAddSingleton<IStep02Helper, Step02Helper>();
            services.TryAddSingleton<IStep03Helper, Step03Helper>();
            services.TryAddSingleton<IStep04Helper, Step04Helper>();
            services.TryAddSingleton<IToolsHelper, ToolsHelper>();

            services.TryAddSingleton<IReleasesLastest, ReleasesLastest>();

            services.TryAddScoped<IManagerUpdateService, ManagerUpdateService>();
        }
    }
}