using NSubstitute;
using NSubstitute.Equivalency;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.IssueTypes;
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
    public class IssueTypeSynchronizerServiceTests : BaseAsyncMethods
    {
        private readonly IIssueTypeRepository repository;

        private readonly IIssueTypeGetAll api;

        private readonly IIssueTypeSynchronizerService service;

        public IssueTypeSynchronizerServiceTests()
        {
            repository = CreateRepository();
            api = CreateApi();

            service = new IssueTypeSynchronizerService(repository, api, new JiraIssueTypeDtoToEntityMapper());
        }

        private static IIssueTypeRepository CreateRepository()
            => Substitute.For<IIssueTypeRepository>();

        private static IIssueTypeGetAll CreateApi()
        {
            var api = Substitute.For<IIssueTypeGetAll>();
            api.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                        Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                        Arg.Any<CancellationToken>())
               .Returns(new IssueTypeDto[] { IssueTypeDtoMock.CreateEpic() });
            return api;
        }

        [Fact(DisplayName = "[IssueTypeSynchronizerService.SynchronizeData] Deve adicionar todas as informações do tipo IssueType quando não for encontrada na base de dados.")]
        public async void DeveAdicionarQuandoRegistroNaoEncontrado()
        {
            SetRepositoryExistsByKeyAsyncReturns(false);

            await service.SynchronizeData(IssueConfigurationSynchronizerDtoMock.Create(), GetCancellationToken());


            await repository.Received(1)
                            .CreateAsync(ArgEx.IsEquivalentTo(IssueTypeMock.CreateEpic(), cfg => cfg.Excluding(p => p.Uuid)),
                                         Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[StatusCategorySynchronizerService.SynchronizeData] Deve prosseguir com sincronização quando o tipo IssueType for encontrada na base de dados.")]
        public async void DeveProsseguirQuandoRegistroEncontrado()
        {
            SetRepositoryExistsByKeyAsyncReturns(true);

            await service.SynchronizeData(IssueConfigurationSynchronizerDtoMock.Create(), GetCancellationToken());

            await repository.Received(0)
                            .CreateAsync(Arg.Any<IssueType>(),
                                         Arg.Any<CancellationToken>());
        }

        private void SetRepositoryExistsByKeyAsyncReturns(bool value)
            => repository.ExistsByKeyAsync(Arg.Any<long>(),
                                           Arg.Any<CancellationToken>())
                         .Returns(value);
    }
}