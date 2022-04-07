using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stefanini.ViaReport.Core.Extensions;
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
            var applicationConfiguration = Configuration.GetApplicationConfiguration();
            var jiraConfiguration = Configuration.GetJiraConfiguration();

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
    }
}