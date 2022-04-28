using Microsoft.Extensions.Configuration;
using Stefanini.Core.TestingTools.Helpers;
using Stefanini.ViaReport.Core.Data.Configurations;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Primitives
{
    public class IConfigurationMock : BaseConfigurationMockHelper
    {
        private static readonly string CONFIGURATION_SUFFIX = "Configuration";

        public static IConfiguration CreateWithAppAndJiraConfiguration()
            => CreateConfigurationInstance(DataSettingsWithAppAndJiraConfiguration());

        private static Dictionary<string, string> DataSettingsWithAppAndJiraConfiguration()
            => new()
            {
                { $"{GetClassName<ApplicationConfiguration>()}:{nameof(ApplicationConfiguration.ShowTools)}", $"true" },
                { $"{GetClassName<JiraConfiguration>()}:{nameof(JiraConfiguration.Path)}", $"{DataMock.JIRA_HOST}" },
                { $"{GetClassName<JiraConfiguration>()}:{nameof(JiraConfiguration.EasyBIAccount)}", $"{DataMock.TEXT_EASYBI_ACCOUNT}" },
                { $"{GetClassName<JiraConfiguration>()}:{nameof(JiraConfiguration.Cache)}", $"{DataMock.INT_CACHE_MINUTES}" },
            };

        private static string GetClassName<T>()
            => typeof(T).Name
                        .Replace(CONFIGURATION_SUFFIX, string.Empty);
    }
}