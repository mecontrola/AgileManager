using FluentAssertions;
using Stefanini.ViaReport.Core.Mappers.DtoToEntity;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Mappers.DtoToEntity
{
    public class JiraStatusDtoToEntityMapperTests
    {
        private readonly IJiraStatusDtoToEntityMapper mapper;

        public JiraStatusDtoToEntityMapperTests()
        {
            mapper = new JiraStatusDtoToEntityMapper();
        }

        [Fact(DisplayName = "[JiraStatusDtoToEntityMapper.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[JiraStatusDtoToEntityMapper.ToMap] Deve converter um objeto StatusDto para Status.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(StatusDtoMock.CreateDone());
            var expected = StatusMock.CreateDone();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[JiraStatusDtoToEntityMapper.ToMapList] Deve converter uma lista de objetos do tipo StatusDto para Status.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(StatusDtoMock.CreateListDone());
            var expected = StatusMock.CreateListDone();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}