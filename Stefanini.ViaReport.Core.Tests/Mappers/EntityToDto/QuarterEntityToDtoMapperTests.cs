using FluentAssertions;
using Stefanini.ViaReport.Core.Mappers.EntityToDto;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Mappers.EntityToDto
{
    public class QuarterEntityToDtoMapperTests
    {
        private readonly IQuarterEntityToDtoMapper mapper;

        public QuarterEntityToDtoMapperTests()
        {
            mapper = new QuarterEntityToDtoMapper();
        }

        [Fact(DisplayName = "[QuarterEntityToDtoMapper.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[QuarterEntityToDtoMapper.ToMap] Deve converter um objeto Quarter para QuarterDto.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(QuarterMock.CreateQ12000());
            var expected = QuarterDtoMock.CreateQ12000();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[QuarterEntityToDtoMapper.ToMapList] Deve converter uma lista de objetos do tipo Quarter para QuarterDto.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(QuarterMock.CreateList());
            var expected = QuarterDtoMock.CreateList();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}