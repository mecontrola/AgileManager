using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Jira
{
   /* public class CacheMock : BaseCacheJiraIntegration
    {
        protected CacheMock()
            : base(SettingsServiceMock.Create())
        { }

        public static CacheMock Create()
            => new()
            {
                IsCached = false
            };

        public static CacheMock CreateWithCache()
            => new()
            {
                IsCached = true
            };


        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
        public void SaveFile()
            => SaveCacheFile(DataMock.ISSUE_LINK_1, DataMock.JSON_CLASS_TEST);

        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
        public string LoadFile()
            => LoadCacheFile(DataMock.ISSUE_LINK_1);

        public bool IsLoadCachedFile()
            => IsLoadCachedFile(DataMock.ISSUE_LINK_1);

        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
        public void ChangeLastAccessTimeTo1HourAgo()
        {
            var filename = GenerateFileName(DataMock.ISSUE_LINK_1);
            var lastAccessTime = File.GetLastAccessTime(filename);

            File.SetLastAccessTime(filename, lastAccessTime.AddHours(-1));
        }

        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
        public void ClearFiles()
        {
            var filename = GenerateFileName(DataMock.ISSUE_LINK_1);
            var pathname = Path.GetDirectoryName(filename);

            if (Directory.Exists(pathname))
                Directory.Delete(pathname, true);
        }
    }*/
}