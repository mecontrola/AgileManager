using NSubstitute;
using NSubstitute.Equivalency;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
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
            api.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                        Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                        Arg.Any<CancellationToken>())
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