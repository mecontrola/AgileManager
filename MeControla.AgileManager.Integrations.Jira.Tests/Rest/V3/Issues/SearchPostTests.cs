using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos.Inputs;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest.V3.Issues
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
            var response = await service.Execute(CreateInput(), GetCancellationToken());

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