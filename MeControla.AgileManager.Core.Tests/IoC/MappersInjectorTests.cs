using FluentAssertions;
using MeControla.AgileManager.TestingTools.FluentAssertions.Extensions;
using MeControla.AgileManager.Core.IoC;
using MeControla.AgileManager.Core.Mappers;
using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Core.Mappers.EntityToDto;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.IoC
{
    public class MappersInjectorTests : BaseInjectorTests
    {
        private const int TOTAL_RECORDS = 12;

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
            serviceCollection.ShouldAsSingleton<IQuarterEntityToDtoMapper, QuarterEntityToDtoMapper>();
        }
    }
}