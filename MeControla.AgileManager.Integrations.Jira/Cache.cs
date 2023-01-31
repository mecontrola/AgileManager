using MeControla.AgileManager.Integrations.Jira.Abstrations;
using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.Integrations.Jira.Exceptions;
using MeControla.Core.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text.Json;

namespace MeControla.AgileManager.Integrations.Jira
{
    public sealed class Cache : ICache
    {
        private const string FOLDER_CACHE = "caches";

        private readonly IOptionsMonitor<CacheConfiguration> configuration;

        public Cache(IOptionsMonitor<CacheConfiguration> configuration)
            => this.configuration = configuration;

        public bool ContainsKey(string key)
        {
            var file = GenerateFileName(key);

            return FileCacheExists(file);
        }

        public T Read<T>(string key)
        {
            var serializedObj = Read(key);
            return JsonSerializer.Deserialize<T>(serializedObj);
        }

        public string Read(string key)
        {
            var filename = GenerateFileName(key);

            if (!FileCacheExists(filename))
                throw new CacheNotFoundException();

            return File.ReadAllText(filename);
        }

        public void Write<T>(string key, T value)
        {
            if (!IsCachedResponse())
                return;

            var serializedObj = JsonSerializer.Serialize(value);
            Write(key, serializedObj);
        }

        public void Write(string key, string value)
        {
            if (!IsCachedResponse())
                return;

            var filename = GenerateFileName(key);

            File.WriteAllText(filename, value);
        }

        public void Clear()
        {
            var path = PathBase();

            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }

        public bool IsExpired(string key)
        {
            var filename = GenerateFileName(key);

            if (!IsCachedResponse() || !FileCacheExists(filename))
                return true;

            var lastAccessTime = File.GetLastAccessTime(filename);

            return lastAccessTime.AddMinutes(configuration.CurrentValue.Cache) < DateTime.Now;
        }

        private static bool FileCacheExists(string file)
            => File.Exists(file);

        private static string GenerateFileName(string key)
            => Path.Combine(PathBase(), GenerateFileNameHash(key));

        private static string GenerateFileNameHash(string key)
            => $"{key.ToMD5()}.cache";

        private static string PathBase()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_CACHE);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        private bool IsCachedResponse()
            => configuration.CurrentValue.Cache > 0;
    }
}