using NSubstitute;
using NSubstitute.Equivalency;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Mappers.DtoToEntity;
using Stefanini.ViaReport.Core.Services.Synchronizers;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Synchronizers;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Entities;
using Stefanini.ViaReport.DataStorage.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services.Synchronizers
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
            api.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                        Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                        Arg.Any<CancellationToken>())
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