using Stefanini.GitHub.Core.Data.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.GitHub.Core.Business
{
    public interface IFindGitHubPullRequestsOpenBusiness
    {
        Task<IList<IssueDto>> GetPullRequestsList(CancellationToken cancellationToken);
    }
}