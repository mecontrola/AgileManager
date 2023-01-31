using MeControla.AgileManager.Integrations.Jira.Data.Configurations;

namespace MeControla.AgileManager.Core.Tests.Mocks.Configurations
{
    public class CacheConfigurationMock
    {
        public static CacheConfiguration Create()
            => new()
            {
                Cache = DataMock.INT_CACHE_MINUTES
            };
    }
}