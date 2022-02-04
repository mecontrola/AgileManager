using Microsoft.AspNetCore.Mvc;
using Stefanini.GitHub.Core.Business;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.GitHub.Web.Controllers
{
    public class GitHubController : ControllerBase
    {
        private readonly IFindGitHubPullRequestsOpenBusiness findGitHubPullRequestsOpenBusiness;

        public GitHubController(IFindGitHubPullRequestsOpenBusiness findGitHubPullRequestsOpenBusiness)
        {
            this.findGitHubPullRequestsOpenBusiness = findGitHubPullRequestsOpenBusiness;
        }

        [HttpGet("/github/prs")]
        public async Task<IActionResult> GetPullRequests(CancellationToken cancellationToken)
        {
            var data = await findGitHubPullRequestsOpenBusiness.GetPullRequestsList(cancellationToken);
            return new JsonResult(data);
        }
    }
}