using Stefanini.ViaReport.Updater.Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public class Step01Helper : IStep01Helper
    {
        private readonly ILocalVersionHelper localVersionHelper;
        private readonly IRemoteVersionHelper remoteVersionHelper;

        public Step01Helper(ILocalVersionHelper localVersionHelper,
                            IRemoteVersionHelper remoteVersionHelper)
        {
            this.localVersionHelper = localVersionHelper;
            this.remoteVersionHelper = remoteVersionHelper;
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            var localVersion = localVersionHelper.GetVersion();
            var remoteVersion = await remoteVersionHelper.GetVersion(cancellationToken);

            if (localVersion == null || remoteVersion == null)
                throw new UpdateNotFoundException();

            if (remoteVersion <= localVersion)
                throw new UpdateNotFoundException();
        }
    }
}