using Stefanini.GitHub.Core.Data.Dto;
using Stefanini.GitHub.Core.Data.Dto.GitHub;
using Stefanini.GitHub.Core.Integrations.GitHub.V3.Search;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.GitHub.Core.Services
{
    public class FindGitHubPullRequestsOpenService : IFindGitHubPullRequestsOpenService
    {
        private readonly IIssuesGet issuesGet;

        public FindGitHubPullRequestsOpenService(IIssuesGet issuesGet)
        {
            this.issuesGet = issuesGet;
        }

        public async Task<IList<IssueDto>> Execute(string username, string password, string query, CancellationToken cancellationToken)
        {
            var data = await issuesGet.Execute(username, password, query, cancellationToken);

            return MountIssuesList(data);
        }

        private static IList<IssueDto> MountIssuesList(SearchIssueDto data)
            => data.Items
                   .Select(itm => ConverToIssue(itm))
                   .ToList();

        private static IssueDto ConverToIssue(SearchIssueItemDto itm)
            => new()
            {
                Title = itm.Title,
                User = itm.User.Login,
                CreateAt = itm.CreatedAt,
                Url = itm.PullRequest.HtmlUrl
            };
    }
}