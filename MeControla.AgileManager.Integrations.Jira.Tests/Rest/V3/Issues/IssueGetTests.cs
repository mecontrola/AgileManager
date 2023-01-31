using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest.V3.Issues
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
            var response = await issueGet.Execute(DataMock.TEXT_KEY_ISSUE_SEA242, GetCancellationToken());

            response.Should().NotBeNull();
            response.Key.Should().Be(DataMock.TEXT_KEY_ISSUE_SEA242);
        }
    }
}