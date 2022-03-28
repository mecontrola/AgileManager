using Microsoft.Extensions.Configuration;
using Stefanini.ViaReport.Core.Data.Configurations;
using Stefanini.ViaReport.Core.Tests.Data.Entities;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Primitives
{
    public class IConfigurationMock
    {
        private static readonly string CONFIGURATION_SUFFIX = "Configuration";

        public static IConfiguration CreateEmpty()
            => CreateConfigurationInstance(new Dictionary<string, string>());

        public static IConfiguration Create()
            => CreateConfigurationInstance(DataSettings());

        private static Dictionary<string, string> DataSettings()
            => new()
            {
                { $"{nameof(ClassTest)}:{nameof(ClassTest.FieldInClass1)}", $"{DataMock.VALUE_DEFAULT_5}" },
                { $"{nameof(ClassTest)}:{nameof(ClassTest.FieldInClass2)}", $"{DataMock.VALUE_DEFAULT_9}" }
            };

        private static IConfiguration CreateConfigurationInstance(IDictionary<string, string> dataSettings)
            => new ConfigurationBuilder().AddInMemoryCollection(dataSettings)
                                         .Build();

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