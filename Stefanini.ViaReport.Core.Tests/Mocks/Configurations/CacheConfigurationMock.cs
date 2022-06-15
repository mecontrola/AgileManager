using Stefanini.ViaReport.Data.Configurations;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Configurations
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