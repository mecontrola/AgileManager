using FluentAssertions;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Data.Dtos.Jira.Inputs;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Integrations.Jira.V2.Projects
{
    public class SearchPostTests : BaseJiraApiTests
    {
        private const int TOTAL_ISSUES = 71;

        private readonly ISearchPost service;

        public SearchPostTests()
            : base()
        {
            ConfigureSearchPost();

            service = new SearchPost(GetSettings());
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