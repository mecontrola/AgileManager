using FluentAssertions;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Issues;
using MeControla.AgileManager.Core.Tests.Mocks;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Integrations.Jira.V2.Issues
{
    public class IssueGetTests : BaseJiraApiTests
    {
        private readonly IIssueGet issueGet;

        public IssueGetTests()
            : base()
        {
            ConfigureIssueGet();

            issueGet = new IssueGet(GetSettings());
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