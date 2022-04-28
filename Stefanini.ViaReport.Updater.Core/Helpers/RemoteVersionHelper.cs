using Stefanini.Core.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public class RemoteVersionHelper : IRemoteVersionHelper
    {
        private readonly IGitHubLastReleaseHelper gitHubLastReleaseHelper;

        public RemoteVersionHelper(IGitHubLastReleaseHelper gitHubLastReleaseHelper)
        {
            this.gitHubLastReleaseHelper = gitHubLastReleaseHelper;
        }

        public async Task<Version> GetVersion(CancellationToken cancellationToken)
        {
            var release = await gitHubLastReleaseHelper.GetLastRelease(cancellationToken);
            return release?.TagName?.GetVersion();
        }
    }
}