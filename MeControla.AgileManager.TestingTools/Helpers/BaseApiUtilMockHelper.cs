using System.Collections.Generic;
using System.IO;

namespace MeControla.AgileManager.TestingTools.Helpers
{
    public class BaseApiUtilMockHelper
    {
        private const string PATH_BASE_DOWNLOAD = @"Mocks\Server\Download";
        private const string PATH_BASE_JSON = @"Mocks\Server\Jsons";

        private static string GetJsonFilePath(string filename)
            => Path.Combine(PATH_BASE_JSON, filename);

        private static string GetDownloadFilePath(string filename)
            => Path.Combine(PATH_BASE_DOWNLOAD, filename);

        public static string ReadJsonFile(string filename)
            => File.ReadAllText(GetJsonFilePath(filename));

        public static string ReadDownloadFile(string filename)
            => File.ReadAllText(GetDownloadFilePath(filename));

        public static IList<string> GetFilenameList()
            => Directory.GetFiles(PATH_BASE_JSON);
    }
}