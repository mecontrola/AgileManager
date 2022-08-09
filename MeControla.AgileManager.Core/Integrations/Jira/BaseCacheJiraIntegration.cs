using MeControla.AgileManager.Data.Configurations;
using MeControla.Kernel.Extensions;
using System;
using System.IO;

namespace MeControla.AgileManager.Core.Integrations.Jira
{
    public abstract class BaseCacheJiraIntegration
    {
        private const string FOLDER_CACHE = "caches";

        private readonly ICacheConfiguration cacheConfiguration;

        protected BaseCacheJiraIntegration(ICacheConfiguration cacheConfiguration)
        {
            this.cacheConfiguration = cacheConfiguration;
        }

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
            => IsCached && cacheConfiguration.Cache > 0;

        protected bool IsLoadCachedFile(string route)
        {
            if (!IsCachedResponse() || !ExistCacheFile(route))
                return false;

            var lastAccessTime = File.GetLastAccessTime(GenerateFileName(route));

            return lastAccessTime.AddMinutes(cacheConfiguration.Cache) > DateTime.Now;
        }
    }
}