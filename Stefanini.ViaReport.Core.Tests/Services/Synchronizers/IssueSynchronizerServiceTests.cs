using NSubstitute;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Services.Synchronizers;
using Stefanini.ViaReport.Core.Services.Synchronizers.ExtraIssueData;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Synchronizers;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities;
using Stefanini.ViaReport.Data.Dtos.Jira.Inputs;
using Stefanini.ViaReport.Data.Entities;
using Stefanini.ViaReport.Data.Parameters;
using Stefanini.ViaReport.DataStorage.Repositories;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Data.Dtos.Jira.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.Services.Synchronizers
{
    public class IssueSynchronizerServiceTests : BaseAsyncMethods
    {
        private const int CALLS_SAVE_ISSUE_IN_REPOSITORY_0 = 0;
        private const int CALLS_SAVE_ISSUE_IN_REPOSITORY_10 = 10;

        private readonly IIssueRepository repository;
        private readonly IIssueTypeRepository issueTypeRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IStatusRepository statusRepository;

        private readonly IIssueGet issueGet;
        private readonly ISearchPost api;

        private readonly IIssueDataSynchronizerService issueDataSynchronizerService;
        private readonly IIssueStatusHistorySynchronizerService issueStatusHistorySynchronizerService;

        private readonly IIssueSynchronizerService service;

        public IssueSynchronizerServiceTests()
        {
            repository = CreateRepository();
            issueTypeRepository = CreateIssueTypeRepository();
            projectRepository = Substitute.For<IProjectRepository>();
            statusRepository = CreateStatusRepository();

            issueGet = Substitute.For<IIssueGet>();
            api = Substitute.For<ISearchPost>();

            issueDataSynchronizerService = Substitute.For<IIssueDataSynchronizerService>();
            issueStatusHistorySynchronizerService = Substitute.For<IIssueStatusHistorySynchronizerService>();

            service = new IssueSynchronizerService(repository,
                                                   issueTypeRepository,
                                                   projectRepository,
                                                   statusRepository,
                                                   issueGet,
                                                   api,
                                                   issueDataSynchronizerService,
                                                   issueStatusHistorySynchronizerService);
        }

        private static IIssueRepository CreateRepository()
            => Substitute.For<IIssueRepository>();

        private static IIssueTypeRepository CreateIssueTypeRepository()
        {
            var repository = Substitute.For<IIssueTypeRepository>();
            repository.FindAllAsync(Arg.Any<CancellationToken>())
                      .Returns(IssueTypeMock.CreateList());
            return repository;
        }

        private static IStatusRepository CreateStatusRepository()
        {
            var repository = Substitute.For<IStatusRepository>();
            repository.FindAllAsync(Arg.Any<CancellationToken>())
                      .Returns(StatusMock.CreateListAll());
            return repository;
        }

        [Fact(DisplayName = "[IssueSynchronizerService.SynchronizeData] Deve finalizar sincronização das Issues quando não encontrar Project informado na base de dados.")]
        public async void DeveFinalizarQuandoProjetoNaoEncontrado()
        {
            SetProjectFindAsyncReturns();

            var configuration = IssueConfigurationSynchronizerDtoMock.Create();
            configuration.Projects = DataMock.PROJECTS_EMPTY;

            await service.SynchronizeData(configuration, GetCancellationToken());


            await issueDataSynchronizerService.Received(CALLS_SAVE_ISSUE_IN_REPOSITORY_0)
                                              .Save(Arg.Any<IssueSynchronizerParam>(),
                                                    Arg.Any<CancellationToken>());

            await issueStatusHistorySynchronizerService.Received(CALLS_SAVE_ISSUE_IN_REPOSITORY_0)
                                                       .Save(Arg.Any<IssueSynchronizerParam>(),
                                                             Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[IssueSynchronizerService.SynchronizeData] Deve executar sincronização das Issues quando encontrar Project informado na base de dados e atualizar as issues quando retornarem do Jira.")]
        public async void DeveExecutarQuandoProjetoEncontradoECarregarIssuesJiraAtualizar()
        {
            SetProjectFindAsyncReturns();
            SetIssueLastUpdatedAsyncReturns(null);
            SetSearchPostExecuteReturns();

            await service.SynchronizeData(IssueConfigurationSynchronizerDtoMock.Create(), GetCancellationToken());


            await issueDataSynchronizerService.Received(CALLS_SAVE_ISSUE_IN_REPOSITORY_10)
                                              .Save(Arg.Any<IssueSynchronizerParam>(),
                                                    Arg.Any<CancellationToken>());

            await issueStatusHistorySynchronizerService.Received(CALLS_SAVE_ISSUE_IN_REPOSITORY_10)
                                                       .Save(Arg.Any<IssueSynchronizerParam>(),
                                                             Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[IssueSynchronizerService.SynchronizeData] Deve executar sincronização das Issues quando encontrar Project informado na base de dados e não atualizar issues quando não retornar listagem do Jira.")]
        public async void DeveExecutarQuandoProjetoEncontradoECarregarIssuesJiraSemAtualizar()
        {
            SetProjectFindAsyncReturns();
            SetIssueLastUpdatedAsyncReturns(DateTime.Now);
            SetSearchPostExecuteReturns();

            await service.SynchronizeData(IssueConfigurationSynchronizerDtoMock.Create(), GetCancellationToken());


            await issueDataSynchronizerService.Received(CALLS_SAVE_ISSUE_IN_REPOSITORY_0)
                                              .Save(Arg.Any<IssueSynchronizerParam>(),
                                                    Arg.Any<CancellationToken>());

            await issueStatusHistorySynchronizerService.Received(CALLS_SAVE_ISSUE_IN_REPOSITORY_0)
                                                       .Save(Arg.Any<IssueSynchronizerParam>(),
                                                             Arg.Any<CancellationToken>());
        }

        private void SetProjectFindAsyncReturns()
            => projectRepository.FindAllInIdListAsync(Arg.Any<long[]>(),
                                                      Arg.Any<CancellationToken>())
                                .Returns(context =>
                                {
                                    var ids = context.ArgAt<long[]>(0);
                                    if (ids.Any(id => id == DataMock.INT_SEARCH_PROJECT_KEY))
                                        return new List<Project> { ProjectMock.CreateSearch() };

                                    return new List<Project>();
                                });

        private void SetIssueLastUpdatedAsyncReturns(DateTime? value)
            => repository.GetLastUpdatedAsync(Arg.Any<long>(),
                                              Arg.Any<CancellationToken>())
                         .Returns(value);

        private void SetSearchPostExecuteReturns()
            => api.Execute(Arg.Any<string>(),
                           Arg.Any<string>(),
                           Arg.Any<SearchInputDto>(),
                           Arg.Any<CancellationToken>())
                  .Returns(context =>
                  {
                      var searchInput = context.ArgAt<SearchInputDto>(2);

                      var value = SearchInputDtoMock.CreatePart1To5From10();
                      if (searchInput.Jql.Equals(value.Jql) && searchInput.StartAt.Equals(value.StartAt))
                          return SearchDtoMock.CreatePart1To5From10();

                      value = SearchInputDtoMock.CreatePart6To10From10();
                      if (searchInput.Jql.Equals(value.Jql) && searchInput.StartAt.Equals(value.StartAt))
                          return SearchDtoMock.CreatePart6To10From10();

                      return SearchDtoMock.CreateEmpty();
                  });
    }
}