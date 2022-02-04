using Stefanini.GitHub.Core.Data.Configurations;
using Stefanini.GitHub.Core.Data.Dto;
using Stefanini.GitHub.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.GitHub.Core.Business
{
    public class FindGitHubPullRequestsOpenBusiness : IFindGitHubPullRequestsOpenBusiness
    {
        private readonly IGitHubConfiguration gitHubConfiguration;

        private readonly IFindGitHubPullRequestsOpenService findGitHubPullRequestsOpenService;

        public FindGitHubPullRequestsOpenBusiness(IGitHubConfiguration gitHubConfiguration,
                                                   IFindGitHubPullRequestsOpenService findGitHubPullRequestsOpenService)
        {
            this.gitHubConfiguration = gitHubConfiguration;
            this.findGitHubPullRequestsOpenService = findGitHubPullRequestsOpenService;
        }

        public async Task<IList<IssueDto>> GetPullRequestsList(CancellationToken cancellationToken)
        {
            var repositories = new Dictionary<string, string>
            {
                { "Android", "vv-viaunica-android" },
                { "iOS", "vv-viaunica-ios" },
                { "Backend Busca", "vv-viaunica-backend-busca" },
                { "Backend Coleta", "vv-viaunica-backend-coleta" },
                { "Search Partners", "vv-searchpartners-api" }
            };
            var items = new List<IssueDto>();

            foreach (var repository in repositories)
            {
                var query = $"repo:viavarejo-internal/{repository.Value}+is:pr+state:open+in:title SEA";
                var data = await findGitHubPullRequestsOpenService.Execute(gitHubConfiguration.Username,
                                                                           gitHubConfiguration.Password,
                                                                           query,
                                                                           cancellationToken);
                data = data.Select(x =>
                {
                    x.Stack = repository.Key;
                    return x;
                }).ToList();

                items.AddRange(data);
            }

            return items;
        }
    }
}