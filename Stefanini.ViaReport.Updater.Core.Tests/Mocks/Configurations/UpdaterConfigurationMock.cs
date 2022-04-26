using Stefanini.ViaReport.Updater.Core.Data.Configurations;

namespace Stefanini.ViaReport.Updater.Core.Tests.Mocks.Configurations
{
    public class UpdaterConfigurationMock
    {
        public static IUpdaterConfiguration Create()
            => new UpdaterConfiguration
            {
                ApplicationName = DataMock.STRING_APPLICATION_NAME,
                FilenameToDownload = DataMock.STRING_FILENAME_TO_DOWNLOAD,
                RenameFileDownloaded = DataMock.STRING_RENAME_FILE_DOWNLOADED,
                GitUrl = DataMock.STRING_GIT_URL
            };
    }
}