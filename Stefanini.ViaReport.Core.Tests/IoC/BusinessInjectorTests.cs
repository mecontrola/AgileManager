using FluentAssertions;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.IoC;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.TestUtils.FluentAssertions.Extensions;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.IoC
{
    public class BusinessInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 4;

        [Fact(DisplayName = "[BusinessInjector.AddBusiness] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddBusiness());

        [Fact(DisplayName = "[BusinessInjector.AddMappers] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddBusiness();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.Should().HaveService<IDashboardBusiness>().WithImplementation<DashboardBusiness>().AsScoped();
            serviceCollection.Should().HaveService<IDownstreamJiraIndicatorsBusiness>().WithImplementation<DownstreamJiraIndicatorsBusiness>().AsScoped();
            serviceCollection.Should().HaveService<IFixVersionBusiness>().WithImplementation<FixVersionBusiness>().AsScoped();
            serviceCollection.Should().HaveService<IUpstreamDownstreamRateBusiness>().WithImplementation<UpstreamDownstreamRateBusiness>().AsScoped();
        }
    }
}