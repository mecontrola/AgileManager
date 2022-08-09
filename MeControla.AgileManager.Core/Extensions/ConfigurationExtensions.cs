using MeControla.AgileManager.Data.Configurations;
using MeControla.Core.Extensions;
using Microsoft.Extensions.Configuration;

namespace MeControla.AgileManager.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IJiraConfiguration GetJiraConfiguration(this IConfiguration configuration)
            => configuration.Load<JiraConfiguration>();
    }
}