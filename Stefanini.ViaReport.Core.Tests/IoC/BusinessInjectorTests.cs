using FluentAssertions;
using Stefanini.Core.TestingTools.FluentAssertions.Extensions;
using Stefanini.ViaReport.Core.Business;
using Stefanini.ViaReport.Core.IoC;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.IoC
{
    public class BusinessInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 8;

        [Fact(DisplayName = "[BusinessInjector.AddBusiness] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddBusiness());

        [Fact(DisplayName = "[BusinessInjector.AddMappers] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddBusiness();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.ShouldAsScoped<IDashboardBusiness, DashboardBusiness>();
            serviceCollection.ShouldAsScoped<IDownstreamJiraIndicatorsBusiness, DownstreamJiraIndicatorsBusiness>();
            serviceCollection.ShouldAsScoped<IFixVersionBusiness, FixVersionBusiness>();
            serviceCollection.ShouldAsScoped<IUpstreamDownstreamRateBusiness, UpstreamDownstreamRateBusiness>();

            serviceCollection.ShouldAsScoped<IProjectBusiness, ProjectBusiness>();
            serviceCollection.ShouldAsScoped<IQuarterBusiness, QuarterBusiness>();
            serviceCollection.ShouldAsScoped<ISettingsBusiness, SettingsBusiness>();
            serviceCollection.ShouldAsScoped<ISynchronizerBusiness, SynchronizerBusiness>();
        }
    }
}