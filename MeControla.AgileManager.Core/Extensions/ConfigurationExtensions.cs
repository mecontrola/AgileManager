using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.Core.Extensions;
using Microsoft.Extensions.Configuration;

namespace MeControla.AgileManager.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static JiraConfiguration GetJiraConfiguration(this IConfiguration configuration)
            => configuration.Load<JiraConfiguration>();
    }
}