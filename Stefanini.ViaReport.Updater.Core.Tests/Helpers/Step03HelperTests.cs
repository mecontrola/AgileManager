using NSubstitute;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Updater.Core.Data.Configurations;
using Stefanini.ViaReport.Updater.Core.Helpers;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Configurations;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Dtos;
using System;
using System.Threading;
using Xunit;

namespace Stefanini.ViaReport.Updater.Core.Tests.Helpers
{
    public class Step03HelperTests : BaseAsyncMethods
    {
        private readonly IUpdaterConfiguration updaterConfiguration;
        private readonly IApplicationArchitectureHelper applicationArchitectureHelper;
        private readonly IDownloadFileHelper downloadFileHelper;
        private readonly IGitHubLastReleaseHelper gitHubLastReleaseHelper;

        private readonly IStep03Helper helper;

        public Step03HelperTests()
        {
            updaterConfiguration = UpdaterConfigurationMock.Create();
            applicationArchitectureHelper = Substitute.For<IApplicationArchitectureHelper>();
            downloadFileHelper = Substitute.For<IDownloadFileHelper>();
            gitHubLastReleaseHelper = Substitute.For<IGitHubLastReleaseHelper>();
            gitHubLastReleaseHelper.GetLastRelease(Arg.Any<CancellationToken>())
                                   .Returns(ReleaseDtoMock.Create());

            helper = new Step03Helper(updaterConfiguration,
                                      applicationArchitectureHelper,
                                      downloadFileHelper,
                                      gitHubLastReleaseHelper);
        }

        [Fact(DisplayName = "[Step03Helper.Run] Deve recuperar o link do arquivo de versão x64 para ser feito o download.")]
        public async void DeveRecuperarLinkVersaoX64ParaDownload()
        {
            static void act(bool show, long percent) { }

            applicationArchitectureHelper.Isx64().Returns(true);

            await helper.Run(act, GetCancellationToken());

            await downloadFileHelper.Received().Start(Arg.Is<string>(x => x.Equals(DataMock.STRING_RELEASE_X64)),
                                                      Arg.Is<string>(x => x.Equals(updaterConfiguration.RenameFileDownloaded)),
                                                      Arg.Any<Action<bool, long>>(),
                                                      Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[Step03Helper.Run] Deve recuperar o link do arquivo de versão x86 para ser feito o download.")]
        public async void DeveRecuperarLinkVersaoX86ParaDownload()
        {
            static void act(bool show, long percent) { }

            applicationArchitectureHelper.Isx64().Returns(false);

            await helper.Run(act, GetCancellationToken());

            await downloadFileHelper.Received().Start(Arg.Is<string>(x => x.Equals(DataMock.STRING_RELEASE_X86)),
                                                      Arg.Is<string>(x => x.Equals(updaterConfiguration.RenameFileDownloaded)),
                                                      Arg.Any<Action<bool, long>>(),
                                                      Arg.Any<CancellationToken>());
        }
    }
}