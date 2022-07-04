using Microsoft.Extensions.Configuration;
using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Data.Configurations;

namespace Stefanini.ViaReport.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IApplicationConfiguration GetApplicationConfiguration(this IConfiguration configuration)
            => configuration.Load<ApplicationConfiguration>();

        public static IJiraConfiguration GetJiraConfiguration(this IConfiguration configuration)
            => configuration.Load<JiraConfiguration>();
    }
}