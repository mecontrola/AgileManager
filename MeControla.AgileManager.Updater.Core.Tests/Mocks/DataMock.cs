using System;

namespace MeControla.AgileManager.Updater.Core.Tests.Mocks
{
    public class DataMock
    {
        public static string URL_EXCEPTION { get; } = "/tests/exception";
        public static string URL_DOWNLOAD_XML { get; } = "/download/file-to-download.xml";
        public static string ERROR_JSON_EXCEPTION_START_WITH { get; } = "Jira Deserialize Error:";
        public static string STRING_APPLICATION_NAME { get; } = "AHM Report.exe";
        public static string STRING_FILENAME_TO_DOWNLOAD { get; } = "AHM.Report-{0}_{1}.zip";
        public static string STRING_RENAME_FILE_DOWNLOADED { get; } = "update.zip";
        public static string STRING_GIT_URL { get; } = "https://api.github.com";
        public static string STRING_RELEASE_X86 { get; } = "https://github.com/mecontrola/Stefanini/releases/download/v1.0.0.4/AHM.Report-v1.0.0.4_x86.zip";
        public static string STRING_RELEASE_X64 { get; } = "https://github.com/mecontrola/Stefanini/releases/download/v1.0.0.4/AHM.Report-v1.0.0.4_x64.zip";

        public static Version VERSION_GITHUB { get; } = new(1, 0, 0, 4);
    }
}