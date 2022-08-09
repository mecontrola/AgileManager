using FluentAssertions;
using MeControla.AgileManager.Core.Integrations.Jira.V2.IssueTypes;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using IssueTypesEnum = MeControla.AgileManager.Data.Enums.IssueTypes;

namespace MeControla.AgileManager.Core.Tests.Integrations.Jira.V2.IssueTypes
{
    public class IssueTypeGetAllTests : BaseJiraApiTests
    {
        private const int TOTAL_ISSUE_TYPES = 29;

        private readonly IIssueTypeGetAll issueTypeGetAll;

        public IssueTypeGetAllTests()
            : base()
        {
            ConfigureIssueTypeGetAll();

            issueTypeGetAll = new IssueTypeGetAll(GetSettings());
        }

        [Fact(DisplayName = "[IssueTypeGetAll.Execute] Deve recuperar a lista de todos os status category cadastrados no Jira.")]
        public async Task DeveRetornarListaProjetosCadastradosJira()
        {
            var response = await issueTypeGetAll.Execute(GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_ISSUE_TYPES);
            response.Any(x => x.Name.Equals(IssueTypesEnum.Epic.ToString())).Should().BeTrue();
        }
    }
}