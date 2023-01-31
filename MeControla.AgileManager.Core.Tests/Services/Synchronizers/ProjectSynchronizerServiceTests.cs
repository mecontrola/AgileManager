using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Core.Services.Synchronizers;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Synchronizers;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Projects;
using MeControla.AgileManager.TestingTools;
using NSubstitute;
using NSubstitute.Equivalency;
using System.Threading;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services.Synchronizers
{
    public class ProjectSynchronizerServiceTests : BaseAsyncMethods
    {
        private readonly IProjectRepository repository;
        private readonly IProjectCategoryRepository projectCategoryRepository;

        private readonly IProjectGetAll api;

        private readonly IProjectSynchronizerService service;

        public ProjectSynchronizerServiceTests()
        {
            repository = CreateRepository();
            projectCategoryRepository = CreateProjectCategoryRepository();
            api = CreateApi();

            service = new ProjectSynchronizerService(repository, projectCategoryRepository, api, new JiraProjectDtoToEntityMapper());
        }

        private static IProjectRepository CreateRepository()
            => Substitute.For<IProjectRepository>();

        private static IProjectCategoryRepository CreateProjectCategoryRepository()
        {
            var repository = Substitute.For<IProjectCategoryRepository>();
            repository.FindAllAsync(Arg.Any<CancellationToken>())
                      .Returns(new ProjectCategory[] { ProjectCategoryMock.CreateAplicativos() });
            return repository;
        }

        private static IProjectGetAll CreateApi()
        {
            var api = Substitute.For<IProjectGetAll>();
            api.Execute(Arg.Any<CancellationToken>())
               .Returns(new ProjectDto[] { ProjectDtoMock.CreateSearch() });
            return api;
        }

        [Fact(DisplayName = "[ProjectSynchronizerService.SynchronizeData] Deve adicionar todas as informações do tipo Project quando não for encontrada na base de dados.")]
        public async void DeveAdicionarQuandoRegistroNaoEncontrado()
        {
            SetRepositoryExistsByKeyAsyncReturns(false);
            SetFindByKeyAsyncReturns(ProjectCategoryMock.CreateAplicativos());

            await service.SynchronizeData(IssueConfigurationSynchronizerDtoMock.Create(), GetCancellationToken());

            await repository.Received()
                            .CreateAsync(ArgEx.IsEquivalentTo(ProjectMock.CreateSearch(), cfg => cfg.Excluding(p => p.Id)
                                                                                                    .Excluding(p => p.Uuid)
                                                                                                    .Excluding(p => p.ProjectCategory)),
                                         Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[StatusCategorySynchronizerService.SynchronizeData] Deve prosseguir com sincronização quando o tipo Project for encontrada na base de dados.")]
        public async void DeveProsseguirQuandoRegistroEncontrado()
        {
            SetRepositoryExistsByKeyAsyncReturns(true);
            SetFindByKeyAsyncReturns(null);

            await service.SynchronizeData(IssueConfigurationSynchronizerDtoMock.Create(), GetCancellationToken());

            await repository.Received(0)
                            .CreateAsync(Arg.Any<Project>(),
                                         Arg.Any<CancellationToken>());
        }

        private void SetRepositoryExistsByKeyAsyncReturns(bool value)
            => repository.ExistsByKeyAsync(Arg.Any<long>(),
                                           Arg.Any<CancellationToken>())
                         .Returns(value);

        private void SetFindByKeyAsyncReturns(ProjectCategory value)
            => projectCategoryRepository.FindByKeyAsync(Arg.Any<long>(),
                                                        Arg.Any<CancellationToken>())
                                        .Returns(value);
    }
}