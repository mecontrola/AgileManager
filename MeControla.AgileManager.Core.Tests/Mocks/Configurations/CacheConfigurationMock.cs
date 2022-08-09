using MeControla.AgileManager.Data.Configurations;

namespace MeControla.AgileManager.Core.Tests.Mocks.Configurations
{
    public class CacheConfigurationMock
    {
        public static ICacheConfiguration Create()
            => new CacheConfiguration
            {
                Cache = DataMock.INT_CACHE_MINUTES
            };
    }
}