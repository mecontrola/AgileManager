using Stefanini.ViaReport.Data.Configurations;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Configurations
{
    public class JiraConfigurationMock
    {
        public static IJiraConfiguration Create()
            => new JiraConfiguration
            {
                Path = DataMock.JIRA_HOST,
                EasyBIAccount = DataMock.TEXT_EASYBI_ACCOUNT,
                Cache = DataMock.INT_CACHE_MINUTES
            };
    }
}