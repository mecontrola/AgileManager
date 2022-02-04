using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stefanini.Core.Extensions;
using Stefanini.GitHub.Core.Data.Configurations;
using Stefanini.GitHub.Core.Integrations.GitHub.V3;
using Stefanini.GitHub.Core.Integrations.GitHub.V3.Search;
using Stefanini.GitHub.Core.Services;

namespace Stefanini.GitHub
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
            var gitHubConfiguration = GetGitHubConfiguration();

            services.AddSingleton(gitHubConfiguration);
            services.AddSingleton<MainWindow>();

            services.AddTransient<IFindGitHubPullRequestsOpenService, FindGitHubPullRequestsOpenService>();

            services.AddSingleton<IUserInfoGet, UserInfoGet>();
            services.AddSingleton<IIssuesGet, IssuesGet>();
        }

        private IGitHubConfiguration GetGitHubConfiguration()
            => Configuration.Load<GitHubConfiguration>();
    }
}