using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using MeControla.AgileManager.TestingTools.Helpers;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Tests.Mocks.Primitives
{
    public class IConfigurationMock : BaseConfigurationMockHelper
    {
        //private static readonly string CONFIGURATION_SUFFIX = "Configuration";

        public static IConfiguration CreateWithJiraConfiguration()
            => CreateConfigurationInstance(DataSettingsWithJiraConfiguration());

        private static Dictionary<string, string> DataSettingsWithJiraConfiguration()
            => new()
            {
                { $"{GetClassName<JiraConfiguration>()}:{nameof(JiraConfiguration.Url)}", $"{DataMock.JIRA_HOST}" },
                { $"{GetClassName<JiraConfiguration>()}:{nameof(JiraConfiguration.Username)}", $"{DataMock.VALUE_USERNAME}" },
                { $"{GetClassName<JiraConfiguration>()}:{nameof(JiraConfiguration.Password)}", $"{DataMock.VALUE_PASSWORD}" },
                { $"{GetClassName<JiraConfiguration>()}:{nameof(JiraConfiguration.Cache)}", $"{DataMock.INT_CACHE_MINUTES}" },
            };

        private static string GetClassName<T>()
            => typeof(T).Name;
        //.Replace(CONFIGURATION_SUFFIX, string.Empty);
    }
}