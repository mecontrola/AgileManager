using FluentAssertions;
using Stefanini.ViaReport.Core.Mappers.DtoToEntity;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Mappers.DtoToEntity
{
    public class JiraStatusCategoryDtoToEntityMapperTests
    {
        private readonly IJiraStatusCategoryDtoToEntityMapper mapper;

        public JiraStatusCategoryDtoToEntityMapperTests()
        {
            mapper = new JiraStatusCategoryDtoToEntityMapper();
        }

        [Fact(DisplayName = "[JiraStatusCategoryDtoToEntityMapper.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[JiraStatusCategoryDtoToEntityMapper.ToMap] Deve converter um objeto StatusCategoryDto para StatusCategory.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(StatusCategoryDtoMock.CreateToDo());
            var expected = StatusCategoryMock.CreateToDo();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[JiraStatusCategoryDtoToEntityMapper.ToMapList] Deve converter uma lista de objetos do tipo StatusCategoryDto para StatusCategory.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(StatusCategoryDtoMock.CreateList());
            var expected = StatusCategoryMock.CreateList();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}