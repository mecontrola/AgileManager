using Stefanini.ViaReport.Data.Configurations;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Configurations
{
    public class ApplicationConfigurationMock
    {
        public static IApplicationConfiguration Create()
            => new ApplicationConfiguration
            {
                ShowTools = true
            };
    }
}