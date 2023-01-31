using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.IssueTypes;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest.V3.IssueTypes
{
    public class IssueTypeGetAllTests : BaseJiraApiTests
    {
        private const int TOTAL_ISSUE_TYPES = 29;

        private readonly IIssueTypeGetAll issueTypeGetAll;

        public IssueTypeGetAllTests()
            : base()
        {
            ConfigureIssueTypeGetAll();

            issueTypeGetAll = new IssueTypeGetAll(GetConfiguration());
        }

        [Fact(DisplayName = "[IssueTypeGetAll.Execute] Deve recuperar a lista de todos os status category cadastrados no Jira.")]
        public async Task DeveRetornarListaProjetosCadastradosJira()
        {
            var response = await issueTypeGetAll.Execute(GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_ISSUE_TYPES);
            response.Any(x => x.Name.Equals(DataMock.ISSUETYPE_NAME_EPIC)).Should().BeTrue();
        }
    }
}