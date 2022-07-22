using FluentAssertions;
using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Core.Mappers;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Mappers
{
    public class IssueDtoToIssueInfoDtoMapperTests
    {
        private readonly IJiraIssueDtoToIssueInfoDtoMapper mapper;

        public IssueDtoToIssueInfoDtoMapperTests()
        {
            mapper = new JiraIssueDtoToIssueDtoMapper(new MountJiraUrlHelper());
        }

        [Fact(DisplayName = "[IssueDtoToIssueInfoDto.ToMap] Deve retornar nulo se for passado um valor nulo.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var actual = mapper.ToMap(null);

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[IssueDtoToIssueInfoDto.ToMap] Deve converter um objeto IssueDto para IssueInfoDto.")]
        public void DeveConverterIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMap(Mocks.Data.Dtos.Jira.IssueDtoMock.CreateIssue1());
            var expected = Mocks.Data.Dtos.IssueDtoMock.CreateIssue1();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[IssueDtoToIssueInfoDto.ToMapList] Deve converter uma lista de objetos do tipo IssueDto para IssueInfoDto.")]
        public void DeveConverterListaIssueDtoParaIssueInfoDto()
        {
            var actual = mapper.ToMapList(Mocks.Data.Dtos.Jira.IssueDtoMock.CreateList());
            var expected = Mocks.Data.Dtos.IssueDtoMock.CreateList();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}