using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Stefanini.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        private static readonly string CONFIGURATION_SUFFIX = "Configuration";

        //[DebuggerStepThrough]
        public static T Load<T>(this IConfiguration configuration)
            where T : new()
        {
            var cfg = new T();
            var section = configuration.GetSection(GetConfigurationName<T>());

            if (!section.Exists())
                return cfg;

            section.Bind(cfg);

            return cfg;
        }

        private static string GetConfigurationName<T>()
            where T : new()
            => typeof(T).Name.Replace(CONFIGURATION_SUFFIX, string.Empty).ToLower();
    }
}