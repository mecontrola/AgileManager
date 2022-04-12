using FluentAssertions;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Tests.Mocks;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira.V2.Issues
{
    public class IssueGetTests : BaseJiraApiTests
    {
        private readonly IIssueGet issueGet;

        public IssueGetTests()
            : base()
        {
            ConfigureIssueGet();

            issueGet = new IssueGet(GetConfiguration());
        }

        [Fact(DisplayName = "[IssueGet.Execute] Deve recuperar a issue especificada cadastrada no Jira.")]
        public async Task DeveRetornarListaProjetosCadastradosJira()
        {
            var response = await issueGet.Execute(DataMock.VALUE_USERNAME,
                                                  DataMock.VALUE_PASSWORD,
                                                  DataMock.TEXT_KEY_ISSUE_SEA242,
                                                  GetCancellationToken());

            response.Should().NotBeNull();
            response.Key.Should().Be(DataMock.TEXT_KEY_ISSUE_SEA242);
        }
    }
}