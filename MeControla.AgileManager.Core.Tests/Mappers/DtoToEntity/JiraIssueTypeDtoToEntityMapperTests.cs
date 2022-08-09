using FluentAssertions;
using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Mappers.DtoToEntity
{
    public class JiraIssueTypeDtoToEntityMapperTests
    {
        private readonly IJiraIssueTypeDtoToEntityMapper mapper;

        public JiraIssueTypeDtoToEntityMapperTests()
        {
            mapper = new JiraIssueTypeDtoToEntityMapper();
        }

        [Fact(DisplayName = "[JiraIssueTypeDtoToEntityMapper.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[JiraIssueTypeDtoToEntityMapper.ToMap] Deve converter um objeto IssueTypeDto para IssueType.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(IssueTypeDtoMock.CreateBug());
            var expected = IssueTypeMock.CreateBug();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[JiraIssueTypeDtoToEntityMapper.ToMapList] Deve converter uma lista de objetos do tipo IssueTypeDto para IssueType.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(IssueTypeDtoMock.CreateList());
            var expected = IssueTypeMock.CreateList();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}