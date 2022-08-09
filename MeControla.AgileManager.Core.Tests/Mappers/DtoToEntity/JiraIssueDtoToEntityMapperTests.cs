using FluentAssertions;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Mappers.DtoToEntity
{
    public class JiraIssueDtoToEntityMapperTests
    {
        private readonly IJiraIssueDtoToEntityMapper mapper;

        public JiraIssueDtoToEntityMapperTests()
        {
            mapper = new JiraIssueDtoToEntityMapper(new IssueFieldsValidationHelper(), new MountJiraUrlHelper());
        }

        [Fact(DisplayName = "[JiraIssueDtoToEntityMapper.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[JiraIssueDtoToEntityMapper.ToMap] Deve converter um objeto IssueDto para Issue.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(IssueDtoMock.CreateIssue1());
            var expected = IssueMock.CreateIssue1();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[JiraIssueDtoToEntityMapper.ToMapList] Deve converter uma lista de objetos do tipo IssueDto para Issue.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(IssueDtoMock.CreateList());
            var expected = IssueMock.CreateList();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}