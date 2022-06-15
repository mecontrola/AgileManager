using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Mappers.EntityToDto;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos;
using Stefanini.ViaReport.Core.Tests.Mocks.Repositories;
using Stefanini.ViaReport.DataStorage.Repositories;
using System.Linq;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services
{
    public class ProjectServiceTests : BaseAsyncMethods
    {
        private readonly IProjectRepository projectRepository;

        private readonly IProjectService projectService;

        public ProjectServiceTests()
        {
            projectRepository = ProjectRepositoryMock.Create();
            var projectCategoryEntityToDtoMapper = new ProjectCategoryEntityToDtoMapper();
            var projectEntityToDtoMapper = new ProjectEntityToDtoMapper(projectCategoryEntityToDtoMapper);

            projectService = new ProjectService(projectRepository, projectEntityToDtoMapper);
        }

        [Fact(DisplayName = "[ProjectService.LoadAllAsync] Deve listar todos os projetos cadastrados.")]
        public async void DeveListarTodosProjetos()
        {
            var actual = await projectService.LoadAllAsync(GetCancellationToken());
            var expected = ProjectDtoMock.CreateListWithSearchLoyaltySelected().OrderBy(x => x.Name);

            actual.OrderBy(x => x.Name).Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[ProjectService.LoadSelectedAsync] Deve listar todos os projetos cadastrados selecionados.")]
        public async void DeveListarTodosProjetosSelecionados()
        {
            var actual = await projectService.LoadSelectedAsync(GetCancellationToken());
            var expected = ProjectDtoMock.CreateListSelected().OrderBy(x => x.Name);

            actual.OrderBy(x => x.Name).Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[ProjectService.LoadSelectedAsync] Deve listar todos os Ids dos projetos cadastrados selecionados.")]
        public async void DeveListarTodosIdsProjetosSelecionados()
        {
            var actual = await projectService.LoadSelectedIdsAsync(GetCancellationToken());
            var expected = ProjectDtoMock.CreateListSelected().Select(x => x.Id).OrderBy(x => x);

            actual.OrderBy(x => x).Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[ProjectService.LoadSelectedAsync] Deve deselecionar todos os projetos e selecionar os Ids informados.")]
        public async void DeveSalvarComoSelecionadosIdsInformados()
        {
            var ids = new long[] { DataMock.INT_ID_3, DataMock.INT_ID_4 };

            await projectService.SetSelectedByIdAsync(ids, GetCancellationToken());

            var actual = await projectService.LoadSelectedIdsAsync(GetCancellationToken());

            actual.OrderBy(x => x).Should().BeEquivalentTo(ids);
        }
    }
}