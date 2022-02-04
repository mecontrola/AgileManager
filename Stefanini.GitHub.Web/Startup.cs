using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stefanini.Core.Extensions;
using Stefanini.GitHub.Core.Business;
using Stefanini.GitHub.Core.Data.Configurations;
using Stefanini.GitHub.Core.Integrations.GitHub.V3;
using Stefanini.GitHub.Core.Integrations.GitHub.V3.Search;
using Stefanini.GitHub.Core.Services;

namespace Stefanini.GitHub.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();

            var gitHubConfiguration = GetGitHubConfiguration();

            services.AddSingleton(gitHubConfiguration);

            services.AddTransient<IFindGitHubPullRequestsOpenBusiness, FindGitHubPullRequestsOpenBusiness>();

            services.AddTransient<IFindGitHubPullRequestsOpenService, FindGitHubPullRequestsOpenService>();

            services.AddSingleton<IUserInfoGet, UserInfoGet>();
            services.AddSingleton<IIssuesGet, IssuesGet>();
        }

        private IGitHubConfiguration GetGitHubConfiguration()
            => Configuration.Load<GitHubConfiguration>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}