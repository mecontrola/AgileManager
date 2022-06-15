using NSubstitute;
using NSubstitute.Equivalency;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.StatusCategories;
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
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services.Synchronizers
{
    public class StatusCategorySynchronizerServiceTests : BaseAsyncMethods
    {
        private readonly IStatusCategoryRepository repository;

        private readonly IStatusCategoryGetAll api;

        private readonly IStatusCategorySynchronizerService service;

        public StatusCategorySynchronizerServiceTests()
        {
            repository = CreateRepository();
            api = CreateApi();

            service = new StatusCategorySynchronizerService(repository, api, new JiraStatusCategoryDtoToEntityMapper());
        }

        private static IStatusCategoryRepository CreateRepository()
            => Substitute.For<IStatusCategoryRepository>();

        private static IStatusCategoryGetAll CreateApi()
        {
            var api = Substitute.For<IStatusCategoryGetAll>();
            api.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                        Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                        Arg.Any<CancellationToken>())
               .Returns(new StatusCategoryDto[] { StatusCategoryDtoMock.CreateToDo() });
            return api;
        }

        [Fact(DisplayName = "[StatusCategorySynchronizerService.SynchronizeData] Deve adicionar todas as informações do tipo StatusCategory quando não for encontrada na base de dados.")]
        public async void DeveAdicionarQuandoRegistroNaoEncontrado()
        {
            SetRepositoryExistsByKeyAsyncReturns(false);

            await service.SynchronizeData(IssueConfigurationSynchronizerDtoMock.Create(), GetCancellationToken());


            await repository.Received(1)
                            .CreateAsync(ArgEx.IsEquivalentTo(StatusCategoryMock.CreateToDo(), cfg => cfg.Excluding(p => p.Uuid)),
                                         Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[StatusCategorySynchronizerService.SynchronizeData] Deve prosseguir com sincronização quando o tipo StatusCategory for encontrada na base de dados.")]
        public async void DeveProsseguirQuandoRegistroEncontrado()
        {
            SetRepositoryExistsByKeyAsyncReturns(true);

            await service.SynchronizeData(IssueConfigurationSynchronizerDtoMock.Create(), GetCancellationToken());

            await repository.Received(0)
                            .CreateAsync(Arg.Any<StatusCategory>(),
                                         Arg.Any<CancellationToken>());
        }

        private void SetRepositoryExistsByKeyAsyncReturns(bool value)
            => repository.ExistsByKeyAsync(Arg.Any<long>(),
                                           Arg.Any<CancellationToken>())
                         .Returns(value);
    }
}