using FluentAssertions;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Core.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Integrations.Jira.V2.Projects
{
    public class ProjectGetAllTests : BaseJiraApiTests
    {
        private const int TOTAL_PROJECTS = 368;

        private readonly IProjectGetAll projectGetAll;

        public ProjectGetAllTests()
            : base()
        {
            ConfigureProjectGetAll();

            projectGetAll = new ProjectGetAll(GetSettings());
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