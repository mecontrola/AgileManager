using FluentAssertions;
using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Mappers.DtoToEntity
{
    public class JiraProjectCategoryDtoToEntityMapperTests
    {
        private readonly IJiraProjectCategoryDtoToEntityMapper mapper;

        public JiraProjectCategoryDtoToEntityMapperTests()
        {
            mapper = new JiraProjectCategoryDtoToEntityMapper();
        }

        [Fact(DisplayName = "[JiraProjectCategoryDtoToEntityMapper.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[JiraProjectCategoryDtoToEntityMapper.ToMap] Deve converter um objeto ProjectCategoryDto para ProjectCategory.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(ProjectCategoryDtoMock.CreateAplicativos());
            var expected = ProjectCategoryMock.CreateAplicativosFromJira();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[JiraProjectCategoryDtoToEntityMapper.ToMapList] Deve converter uma lista de objetos do tipo ProjectCategoryDto para ProjectCategory.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(ProjectCategoryDtoMock.CreateList());
            var expected = ProjectCategoryMock.CreateListFromJira();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}