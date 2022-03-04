using FluentAssertions;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira.V2.Projects
{
    public class SearchPostTests : BaseJiraApiTests
    {
        private const int TOTAL_ISSUES = 71;

        private readonly ISearchPost service;

        public SearchPostTests()
            : base()
        {
            ConfigureSearchPost();

            service = new SearchPost(GetConfiguration());
        }

        [Fact(DisplayName = "[SearchPost.Execute] Deve retornar as informações da sessão do usuário autenciado no Jira.")]
        public async Task DeveRetornarDadosSessaoUsuarioJira()
        {
            var response = await service.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, CreateInput(), GetCancellationToken());

            response.Should().NotBeNull();
            response.Issues.Should().HaveCount(TOTAL_ISSUES);
            response.Issues.Any(x => x.Key.Equals(DataMock.TEXT_KEY_ISSUE_SEA242)).Should().BeTrue();
        }

        private static SearchInputDto CreateInput()
            => new()
            {
                Jql = $"project = '{DataMock.TEXT_SEARCH_PROJECT}'",
                MaxResults = 256,
                StartAt = 0,
                Fields = new[] { "names" }
            };
    }
}