using NSubstitute;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Core.Helpers;
using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Entities;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Parameters;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.DataStorage.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.Services.Synchronizers.ExtraIssueData
{
    public class IssueDataSynchronizerServiceTests : BaseAsyncMethods
    {
        private readonly IIssueRepository issueRepository;

        private readonly IIssueDataSynchronizerService issueDataSynchronizerService;

        public IssueDataSynchronizerServiceTests()
        {
            var jiraIssueDtoToEntityMapper = new JiraIssueDtoToEntityMapper(new IssueFieldsValidationHelper(), new MountJiraUrlHelper());

            issueRepository = Substitute.For<IIssueRepository>();

            issueDataSynchronizerService = new IssueDataSynchronizerService(issueRepository, jiraIssueDtoToEntityMapper);
        }

        [Fact(DisplayName = "[IssueDataSynchronizerService.Save] Deve adicionar as informações da issue quando não existir os dados no banco de dados.")]
        public async void DeveAdicionarIssueInexistente()
        {
            SetIssueFindByKeyAsyncReturns(null);

            await issueDataSynchronizerService.Save(IssueSynchronizerParamMock.Create(), GetCancellationToken());

            await issueRepository.Received(1)
                                 .CreateAsync(Arg.Is<Issue>(value => value.Updated.Equals(DataMock.DATETIME_FIRST_DAY_YEAR)
                                                                  && value.StatusId.Equals(DataMock.INT_ID_5)),
                                              Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "[IssueDataSynchronizerService.Save] Deve atualizar as informações da issue quando existir os dados no banco de dados.")]
        public async void DeveAtualizarIssueExistente()
        {
            var updated = DataMock.DATETIME_FIRST_DAY_YEAR.AddDays(2);
            var @param = IssueSynchronizerParamMock.Create();
            @param.IssueDto.Fields.Updated = updated;
            @param.IssueDto.Fields.Status = StatusDtoMock.CreateEmDesenvolvimento();

            SetIssueFindByKeyAsyncReturns(IssueMock.CreateAllFilledStory());

            await issueDataSynchronizerService.Save(@param, GetCancellationToken());

            await issueRepository.Received(1)
                                 .UpdateAsync(Arg.Is<Issue>(value => value.Updated.Equals(updated)
                                                                  && value.StatusId.Equals(DataMock.INT_ID_6)),
                                              Arg.Any<CancellationToken>());
        }

        private void SetIssueFindByKeyAsyncReturns(Issue issue)
        {
            issueRepository.FindByKeyAsync(Arg.Any<string>(),
                                           Arg.Any<CancellationToken>())
                           .Returns(Task.FromResult(issue));
        }
    }
}