using Stefanini.ViaReport.Core.Data.Configurations;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Configurations
{
    public class CacheConfigurationMock
    {
        public static ICacheConfiguration Create()
            => new CacheConfiguration
            {
                Cache = 10
            };
    }
}