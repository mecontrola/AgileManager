using FluentAssertions;
using Stefanini.ViaReport.Core.Mappers.EntityToDto;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Mappers.EntityToDto
{
    public class IssueEntityToDtoMapperTests
    {
        private readonly IIssueEntityToDtoMapper mapper;

        public IssueEntityToDtoMapperTests()
        {
            mapper = new IssueEntityToDtoMapper();
        }

        [Fact(DisplayName = "[IssueEntityToDtoMapper.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[IssueEntityToDtoMapper.ToMap] Deve converter um objeto Issue para IssueDto.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(IssueMock.CreateAllFilledStory());
            var expected = IssueDtoMock.CreateAllFilledStory();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[IssueEntityToDtoMapper.ToMapList] Deve converter uma lista de objetos do tipo Issue para IssueDto.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(IssueMock.CreateListAllFilled());
            var expected = IssueDtoMock.CreateListAllFilled();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}