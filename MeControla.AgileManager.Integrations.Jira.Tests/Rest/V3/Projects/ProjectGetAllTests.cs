using FluentAssertions;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Projects;
using MeControla.AgileManager.Integrations.Jira.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Rest.V3.Projects
{
    public class ProjectGetAllTests : BaseJiraApiTests
    {
        private const int TOTAL_PROJECTS = 368;

        private readonly IProjectGetAll projectGetAll;

        public ProjectGetAllTests()
            : base()
        {
            ConfigureProjectGetAll();

            projectGetAll = new ProjectGetAll(GetConfiguration());
        }

        [Fact(DisplayName = "[ProjectGetAll.Execute] Deve recuperar a lista de todos os projetos cadastrados no Jira.")]
        public async Task DeveRetornarListaProjetosCadastradosJira()
        {
            var response = await projectGetAll.Execute(GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_PROJECTS);
            response.Any(x => x.Name.ToLower().Equals(DataMock.TEXT_SEARCH_PROJECT.ToLower())).Should().BeTrue();
        }
    }
}