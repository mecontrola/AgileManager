using MeControla.AgileManager.Integrations.Jira.Data.Configurations;

namespace MeControla.AgileManager.Core.Tests.Mocks.Configurations
{
    public class JiraConfigurationMock
    {
        public static JiraConfiguration Create()
            => new()
            {
                Url = DataMock.JIRA_HOST,
                Username = DataMock.VALUE_USERNAME,
                Password = DataMock.VALUE_PASSWORD,
                Cache = DataMock.INT_CACHE_MINUTES
            };
    }
}