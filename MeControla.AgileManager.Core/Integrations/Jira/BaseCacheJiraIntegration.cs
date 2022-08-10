using MeControla.AgileManager.Core.Services;
using MeControla.Kernel.Extensions;
using System;
using System.IO;

namespace MeControla.AgileManager.Core.Integrations.Jira
{
    public abstract class BaseCacheJiraIntegration : BaseConfigurationJiraIntegration
    {
        private const string FOLDER_CACHE = "caches";

        protected BaseCacheJiraIntegration(ISettingsService settings)
            : base(settings)
        { }

        protected bool IsCached { get; set; } = false;

        protected static string LoadCacheFile(string url)
            => File.ReadAllText(GenerateFileName(url));

        private static bool ExistCacheFile(string url)
            => File.Exists(GenerateFileName(url));

        protected static void SaveCacheFile(string url, string json)
            => File.WriteAllText(GenerateFileName(url), json);

        protected static string GenerateFileName(string url)
            => Path.Combine(PathBase(), $"{url.ToMD5()}.cache");

        private static string PathBase()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_CACHE);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        protected bool IsCachedResponse()
            => IsCached && JiraConfiguration.Cache > 0;

        protected bool IsLoadCachedFile(string route)
        {
            LoadJiraConfiguration();

            if (!IsCachedResponse() || !ExistCacheFile(route))
                return false;

            var lastAccessTime = File.GetLastAccessTime(GenerateFileName(route));

            return lastAccessTime.AddMinutes(JiraConfiguration.Cache) > DateTime.Now;
        }
    }
}