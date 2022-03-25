using FluentAssertions;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using Stefanini.ViaReport.Core.Tests.Mocks.Services;
using Stefanini.ViaReport.Core.Tests.TestUtils;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class JiraProjectsServiceTests : BaseAsyncMethods
    {
        private readonly IJiraProjectsService service;

        public JiraProjectsServiceTests()
        {
            var projectGetAll = ProjectGetAllMock.Create();

            service = new JiraProjectsService(projectGetAll);
        }

        [Fact(DisplayName = "[JiraProjectsService.LoadList] Deve retornar a lista de projetos cadastrados no Jira organizados por categoria.")]
        public async Task DeveListarProjetosJira()
        {
            var expected = JiraProjectDtoMock.Create();
            var actual = await service.LoadList(DataMock.VALUE_USERNAME, DataMock.VALUE_PASSWORD, GetCancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }
    }
}