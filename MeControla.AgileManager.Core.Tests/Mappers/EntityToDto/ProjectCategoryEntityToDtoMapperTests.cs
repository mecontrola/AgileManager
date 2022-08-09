using FluentAssertions;
using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Mappers.EntityToDto
{
    public class ProjectCategoryEntityToDtoMapperTests
    {
        private readonly IProjectCategoryEntityToDtoMapper mapper;

        public ProjectCategoryEntityToDtoMapperTests()
        {
            mapper = new ProjectCategoryEntityToDtoMapper();
        }

        [Fact(DisplayName = "[ProjectCategoryEntityToDtoMapper.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[ProjectCategoryEntityToDtoMapper.ToMap] Deve converter um objeto ProjectCategory para ProjectCategoryDto.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(ProjectCategoryMock.CreateAplicativos());
            var expected = ProjectCategoryDtoMock.CreateAplicativos();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[ProjectCategoryEntityToDtoMapper.ToMapList] Deve converter uma lista de objetos do tipo ProjectCategory para ProjectCategoryDto.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(ProjectCategoryMock.CreateList());
            var expected = ProjectCategoryDtoMock.CreateList();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}