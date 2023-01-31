using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Core.Services.Synchronizers;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Synchronizers;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Statuses;
using MeControla.AgileManager.TestingTools;
using NSubstitute;
using NSubstitute.Equivalency;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services.Synchronizers
{
    public class StatusSynchronizerServiceTests : BaseAsyncMethods
    {
        private readonly IStatusRepository repository;
        private readonly IStatusCategoryRepository statusCategoryRepository;

        private readonly IStatusGetAll api;

        private readonly IStatusSynchronizerService service;

        public StatusSynchronizerServiceTests()
        {
            repository = CreateRepository();
            statusCategoryRepository = CreateStatusCategoryRepository();
            api = CreateApi();

            service = new StatusSynchronizerService(repository, statusCategoryRepository, api, new JiraStatusDtoToEntityMapper());
        }

        private static IStatusRepository CreateRepository()
            => Substitute.For<IStatusRepository>();

        private static IStatusCategoryRepository CreateStatusCategoryRepository()
            => Substitute.For<IStatusCategoryRepository>();

        private static IStatusGetAll CreateApi()
        {
            var api = Substitute.For<IStatusGetAll>();
            api.Execute(Arg.Any<CancellationToken>())
               .Returns(new StatusDto[] { StatusDtoMock.CreateDone() });
            return api;
        }

        [Fact(DisplayName = "[StatusCategorySynchronizerService.SynchronizeData] Deve prosseguir com atualização quando o tipo Status for encontrada na base de dados.")]
        public async void DeveAdicionarQuandoRegistroNaoEncontrado()
        {
            SetRepositoryExistsByKeyAsyncReturns(false);
            SetFindByKeyAsyncReturns(StatusCategoryMock.CreateDone());

            await service.SynchronizeData(IssueConfigurationSynchronizerDtoMock.Create(), GetCancellationToken());


            await repository.Received(1)
                            .CreateAsync(ArgEx.IsEquivalentTo(StatusMock.CreateDone(), cfg => cfg.Excluding(p => p.Uuid)),
                                         Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[StatusCategorySynchronizerService.SynchronizeData] Deve prosseguir com sincronização quando o tipo Status for encontrada na base de dados.")]
        public async void DeveProsseguirQuandoRegistroEncontrado()
        {
            SetRepositoryExistsByKeyAsyncReturns(true);
            SetFindByKeyAsyncReturns(null);

            await service.SynchronizeData(IssueConfigurationSynchronizerDtoMock.Create(), GetCancellationToken());

            await repository.Received(0)
                            .CreateAsync(Arg.Any<Status>(),
                                         Arg.Any<CancellationToken>());
        }

        private void SetRepositoryExistsByKeyAsyncReturns(bool value)
            => repository.ExistsByKeyAsync(Arg.Any<long>(),
                                           Arg.Any<CancellationToken>())
                         .Returns(Task.FromResult(value));

        private void SetFindByKeyAsyncReturns(StatusCategory value)
            => statusCategoryRepository.FindByKeyAsync(Arg.Any<long>(),
                                                       Arg.Any<CancellationToken>())
                                       .Returns(Task.FromResult(value));
    }
}