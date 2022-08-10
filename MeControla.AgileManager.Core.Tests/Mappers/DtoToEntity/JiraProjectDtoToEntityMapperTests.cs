using FluentAssertions;
using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Mappers.DtoToEntity
{
    public class JiraProjectDtoToEntityMapperTests
    {
        private readonly IJiraProjectDtoToEntityMapper mapper;

        public JiraProjectDtoToEntityMapperTests()
        {
            mapper = new JiraProjectDtoToEntityMapper();
        }

        [Fact(DisplayName = "[JiraProjectDtoToEntityMapper.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[JiraProjectDtoToEntityMapper.ToMap] Deve converter um objeto ProjectDto para Project.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(ProjectDtoMock.CreateSearch());
            var expected = ProjectMock.CreateSearchFromJira();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[JiraProjectDtoToEntityMapper.ToMapList] Deve converter uma lista de objetos do tipo ProjectDto para Project.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(ProjectDtoMock.CreateList());
            var expected = ProjectMock.CreateListFromJira();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}