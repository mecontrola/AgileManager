using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Core.Services.Synchronizers;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Synchronizers;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.IssueTypes;
using MeControla.AgileManager.TestingTools;
using NSubstitute;
using NSubstitute.Equivalency;
using System.Threading;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services.Synchronizers
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
            api.Execute(Arg.Any<CancellationToken>())
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