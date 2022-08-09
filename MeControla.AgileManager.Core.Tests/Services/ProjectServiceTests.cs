using FluentAssertions;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos;
using MeControla.AgileManager.Core.Tests.Mocks.Repositories;
using MeControla.AgileManager.DataStorage.Repositories;
using System.Linq;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services
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