using FluentAssertions;
using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Mappers.EntityToDto
{
    public class ProjectEntityToDtoMapperTests
    {
        private readonly IProjectEntityToDtoMapper mapper;

        public ProjectEntityToDtoMapperTests()
        {
            var projectCategoryEntityToDtoMapper = new ProjectCategoryEntityToDtoMapper();

            mapper = new ProjectEntityToDtoMapper(projectCategoryEntityToDtoMapper);
        }

        [Fact(DisplayName = "[ProjectEntityToDtoMapper.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[ProjectEntityToDtoMapper.ToMap] Deve converter um objeto Project para ProjectDto.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(ProjectMock.CreateSearch());
            var expected = ProjectDtoMock.CreateSearch();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[ProjectEntityToDtoMapper.ToMapList] Deve converter uma lista de objetos do tipo Project para ProjectDto.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(ProjectMock.CreateList());
            var expected = ProjectDtoMock.CreateList();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}