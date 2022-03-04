using FluentAssertions;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Tests.Mocks;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Integrations.Jira.V2.Projects
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
            var response = await projectGetAll.Execute(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, GetCancellationToken());

            response.Should().NotBeNull();
            response.Should().HaveCount(TOTAL_PROJECTS);
            response.Any(x => x.Name.ToLower().Equals(DataMock.TEXT_SEARCH_PROJECT.ToLower())).Should().BeTrue();
        }
    }
}