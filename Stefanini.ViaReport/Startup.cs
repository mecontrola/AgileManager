using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.IoC;

namespace Stefanini.ViaReport
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
            var applicationConfiguration = GetApplicationConfiguration();
            var jiraConfiguration = GetJiraConfiguration();

            services.AddSingleton(applicationConfiguration);
            services.AddSingleton(jiraConfiguration);
            services.AddSingleton<MainWindow>();
            services.AddSingleton<AuthenticationWindow>();

            services.AddBusiness();
            services.AddHelpers();
            services.AddServices();
            services.AddMappers();
            services.AddIntegrations();
        }

        private IApplicationConfiguration GetApplicationConfiguration()
            => Configuration.Load<ApplicationConfiguration>();

        private IJiraConfiguration GetJiraConfiguration()
            => Configuration.Load<JiraConfiguration>();
    }
}