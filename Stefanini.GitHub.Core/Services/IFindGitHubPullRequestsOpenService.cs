using Stefanini.GitHub.Core.Data.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.GitHub.Core.Services
{
    public interface IFindGitHubPullRequestsOpenService
    {
        Task<IList<IssueDto>> Execute(string username, string password, string query, CancellationToken cancellationToken);
    }
}