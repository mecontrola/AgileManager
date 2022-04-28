using FluentAssertions;
using Stefanini.ViaReport.Updater.Core.Helpers;
using Stefanini.ViaReport.Updater.Core.Tests.Integrations.Github;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks;
using System;
using System.IO;
using Xunit;

namespace Stefanini.ViaReport.Updater.Core.Tests.Helpers
{
    public class DownloadFileHelperTests : BaseGithubApiTests
    {
        private const string RENAME_FILENAME = "update.xml";

        private readonly IDownloadFileHelper helper;

        public DownloadFileHelperTests()
        {
            ConfigureDownloadFile();

            helper = new DownloadFileHelper();
        }

        [Fact(DisplayName = "[DownloadFileHelper.Start]")]
        public async void Deve()
        {
            static void act(bool show, long percent) { }

            await helper.Start(GetUrlToDownload(), RENAME_FILENAME, act, GetCancellationToken());

            File.Exists(FilenameDownloadedAndRenamed()).Should().BeTrue();
            File.Delete(FilenameDownloadedAndRenamed());
        }

        private static string FilenameDownloadedAndRenamed()
            => Path.Combine(AppContext.BaseDirectory, RENAME_FILENAME);

        private string GetUrlToDownload()
            => $"{GetServerUrl()}{DataMock.URL_DOWNLOAD_XML}";
    }
}