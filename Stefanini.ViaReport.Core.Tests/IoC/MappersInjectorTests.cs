using FluentAssertions;
using Stefanini.Core.TestingTools.FluentAssertions.Extensions;
using Stefanini.ViaReport.Core.IoC;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Mappers.DtoToEntity;
using Stefanini.ViaReport.Core.Mappers.EntityToDto;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.IoC
{
    public class MappersInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 11;

        [Fact(DisplayName = "[MappersInjector.AddMappers] Deve gerar exceção quando o serviceCollection for nulo.")]
        public void DeveGerarExcecaoQuandoServiceCollectionNulo()
            => RunServiceCollectionNull(serviceCollection => serviceCollection.AddMappers());

        [Fact(DisplayName = "[MappersInjector.AddMappers] Verifica se a injeções estão corretas.")]
        public void DeveVerificarInjecao()
        {
            serviceCollection.AddMappers();

            serviceCollection.Should().HaveCount(TOTAL_RECORDS);
            serviceCollection.ShouldAsSingleton<IJiraIssueDtoToIssueInfoDtoMapper, JiraIssueDtoToIssueDtoMapper>();
            serviceCollection.ShouldAsSingleton<IJiraIssueDtoToEntityMapper, JiraIssueDtoToEntityMapper>();
            serviceCollection.ShouldAsSingleton<IJiraIssueTypeDtoToEntityMapper, JiraIssueTypeDtoToEntityMapper>();
            serviceCollection.ShouldAsSingleton<IJiraProjectDtoToEntityMapper, JiraProjectDtoToEntityMapper>();
            serviceCollection.ShouldAsSingleton<IJiraProjectCategoryDtoToEntityMapper, JiraProjectCategoryDtoToEntityMapper>();
            serviceCollection.ShouldAsSingleton<IJiraStatusDtoToEntityMapper, JiraStatusDtoToEntityMapper>();
            serviceCollection.ShouldAsSingleton<IJiraStatusCategoryDtoToEntityMapper, JiraStatusCategoryDtoToEntityMapper>();

            serviceCollection.ShouldAsSingleton<IDeliveryLastCycleEpicEntityToDtoMapper, DeliveryLastCycleEpicEntityToDtoMapper>();
            serviceCollection.ShouldAsSingleton<IIssueEntityToDtoMapper, IssueEntityToDtoMapper>();
            serviceCollection.ShouldAsSingleton<IProjectEntityToDtoMapper, ProjectEntityToDtoMapper>();
            serviceCollection.ShouldAsSingleton<IProjectCategoryEntityToDtoMapper, ProjectCategoryEntityToDtoMapper>();
        }
    }
}