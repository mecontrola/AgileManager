using Stefanini.ViaReport.Updater.Core.Data.Dtos;
using Stefanini.ViaReport.Updater.Core.Exceptions;
using Stefanini.ViaReport.Updater.Core.Integrations.Github.Repos;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public class GitHubLastReleaseHelper : IGitHubLastReleaseHelper
    {
        private readonly IReleasesLastest releasesLastest;

        public GitHubLastReleaseHelper(IReleasesLastest releasesLastest)
        {
            this.releasesLastest = releasesLastest;
        }

        public async Task<ReleaseDto> GetLastRelease(CancellationToken cancellationToken)
        {
            try
            {
                return await releasesLastest.Execute(cancellationToken);
            }
            catch (GithubException)
            {
                return null;
            }
        }
    }
}