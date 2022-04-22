using System.Collections.Generic;
using System.IO;

namespace Stefanini.Core.TestingTools.Helpers
{
    public class BaseApiUtilMockHelper
    {
        private const string PATH_BASE_JSON = @"Mocks\Server\Jsons";

        private static string GetFilePath(string filename)
            => Path.Combine(PATH_BASE_JSON, filename);

        public static string ReadJsonFile(string filename)
            => File.ReadAllText(GetFilePath(filename));

        public static IList<string> GetFilenameList()
            => Directory.GetFiles(PATH_BASE_JSON);
    }
}