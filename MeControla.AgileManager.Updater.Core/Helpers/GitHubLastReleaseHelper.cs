using MeControla.AgileManager.Updater.Core.Data.Dtos;
using MeControla.AgileManager.Updater.Core.Exceptions;
using MeControla.AgileManager.Updater.Core.Integrations.Github.Repos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Updater.Core.Helpers
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