using FluentAssertions;
using Stefanini.ViaReport.Core.IoC;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Tests.TestUtils.FluentAssertions.Extensions;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.IoC
{
    public class MappersInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 1;

        [Fact(DisplayName = "[MappersInjector.AddMappers] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddMappers());

        [Fact(DisplayName = "[MappersInjector.AddMappers] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddMappers();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.ShouldAsSingleton<IIssueDtoToIssueInfoDtoMapper, IssueDtoToIssueInfoDtoMapper>();
        }
    }
}