using FluentAssertions;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.IssueTypes;
using Stefanini.ViaReport.Core.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using IssueTypesEnum = Stefanini.ViaReport.Data.Enums.IssueTypes;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira.V2.IssueTypes
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
            var response = await issueTypeGetAll.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_ISSUE_TYPES);
            response.Any(x => x.Name.Equals(IssueTypesEnum.Epic.ToString())).Should().BeTrue();
        }
    }
}