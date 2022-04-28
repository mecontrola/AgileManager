using Stefanini.ViaReport.Updater.Core.Data.Configurations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Helpers
{
    public class Step03Helper : IStep03Helper
    {
        private const string ARCHITECTURE_X86 = "x86";
        private const string ARCHITECTURE_X64 = "x64";

        private readonly IUpdaterConfiguration updaterConfiguration;
        private readonly IApplicationArchitectureHelper applicationArchitectureHelper;
        private readonly IDownloadFileHelper downloadFileHelper;
        private readonly IGitHubLastReleaseHelper gitHubLastReleaseHelper;

        public Step03Helper(IUpdaterConfiguration updaterConfiguration,
                            IApplicationArchitectureHelper applicationArchitectureHelper,
                            IDownloadFileHelper downloadFileHelper,
                            IGitHubLastReleaseHelper gitHubLastReleaseHelper)
        {
            this.updaterConfiguration = updaterConfiguration;
            this.applicationArchitectureHelper = applicationArchitectureHelper;
            this.downloadFileHelper = downloadFileHelper;
            this.gitHubLastReleaseHelper = gitHubLastReleaseHelper;
        }

        public async Task Run(Action<bool, long> fncUpdateProgress, CancellationToken cancellationToken)
        {
            var release = await gitHubLastReleaseHelper.GetLastRelease(cancellationToken);
            var filename = GetFilenameToDownload(release.TagName);
            var asset = release.Assets.First(file => file.Name == filename);

            await downloadFileHelper.Start(asset.BrowserDownloadUrl, updaterConfiguration.RenameFileDownloaded, fncUpdateProgress, cancellationToken);
        }

        private string GetFilenameToDownload(string version)
        {
            var architecture = GetArchitecture();
            return AmountFilenameToDownload(version, architecture);
        }

        private string AmountFilenameToDownload(string version, string architecture)
            => string.Format(updaterConfiguration.FilenameToDownload, version, architecture);

        private string GetArchitecture()
            => applicationArchitectureHelper.Isx64()
             ? ARCHITECTURE_X64
             : ARCHITECTURE_X86;
    }
}