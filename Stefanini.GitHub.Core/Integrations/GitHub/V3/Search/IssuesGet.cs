using Stefanini.GitHub.Core.Data.Configurations;
using Stefanini.GitHub.Core.Data.Dto.GitHub;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.GitHub.Core.Integrations.Routes.GitHubRoutes.Search;

namespace Stefanini.GitHub.Core.Integrations.GitHub.V3.Search
{
    public class IssuesGet : BaseGitHubIntegration, IIssuesGet
    {
        public IssuesGet(IGitHubConfiguration jiraConfiguration)
            : base(jiraConfiguration, new JsonSnakeCaseNamingPolicy())
        { }

        public async Task<SearchIssueDto> Execute(string username,
                                                  string password,
                                                  string query,
                                                  CancellationToken cancellationToken)
        {
            URL = CreateUrl(query);

            return await GetAsync<SearchIssueDto>(username, password, cancellationToken);
        }

        private static string CreateUrl(string query)
            => route.ISSUES_GET.Replace("{query}", query);
    }
}