using FluentAssertions;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Repositories;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.TestingTools;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.DataStorage.Repositories
{
    public class IssueRepositoryTests : BaseAsyncMethods
    {
        private readonly IIssueRepository repository;

        public IssueRepositoryTests()
        {
            repository = IssueRepositoryMock.Create();
        }

        [Fact(DisplayName = "[IssueRepository.FindByKeyAsync] Deve retornar issue quando campo Key válido.")]
        public async void DeveRetornarIssueQuandoCampoKeyValido()
        {
            var actual = await repository.FindByKeyAsync(DataMock.ISSUE_KEY_1, GetCancellationToken());

            actual.Summary.Should().BeEquivalentTo(DataMock.ISSUE_SUMMARY_1);
        }

        [Fact(DisplayName = "[IssueRepository.FindByKeyAsync] Deve retornar null quando campo Key inválido.")]
        public async void DeveRetornarNullQuandoCampoKeyInvalido()
        {
            var actual = await repository.FindByKeyAsync(DataMock.KEY_NOT_FOUND.ToString(), GetCancellationToken());

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[IssueRepository.GetLastUpdated] Deve retornar datetime quando campo projectId válido.")]
        public async void DeveRetornarDateTimeRecenteQuandoCampoProjectIdValido()
        {
            var actual = await repository.GetLastUpdatedAsync(DataMock.ID_PROJECT, GetCancellationToken());

            actual.HasValue.Should().BeTrue();
            actual.Value.Should().Be(DataMock.UPDATED_ISSUE);
        }

        [Fact(DisplayName = "[IssueRepository.GetLastUpdated] Deve retornar null quando campo projectId inválido.")]
        public async void DeveRetornarNullRecenteQuandoCampoProjectIdInvalido()
        {
            var actual = await repository.GetLastUpdatedAsync(DataMock.ID_NOT_FOUND, GetCancellationToken());

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[IssueRepository.FindResolvedInDateRangeAsync] Deve listar todas as issues que foram resolvidas no período informado.")]
        public async void DeveListarIssueResolvidasNoPeriodo()
        {
            var list = await repository.FindResolvedInDateRangeAsync(DataMock.INT_ID_1, DataMock.DATETIME_LAST_CYCLE_INIT, DataMock.DATETIME_LAST_CYCLE_END, GetCancellationToken());

            list.Should().HaveCount(2);
        }

        [Fact(DisplayName = "[IssueRepository.GetCycleBalanceAsync] Deve retornar o percentual dos incrementos de produto feitos com relação a quantidade itens feito durante o período informado.")]
        public async void DeveRetornarPercentualIncrementosNoPeriodo()
        {
            var list = await repository.GetCycleBalanceAsync(DataMock.INT_ID_1, DataMock.DATETIME_LAST_CYCLE_INIT, DataMock.DATETIME_LAST_CYCLE_END, GetCancellationToken());

            list.Should().Be(0);
        }

        [Fact(DisplayName = "[IssueRepository.GetIssuesCancelledInDateRangeByIssueTypeAsync] Deve listar todas as issues que foram canceladas no período e do tipo informado.")]
        public async void DeveListarIssueCanceladasNoPeriodoETipo()
        {
            var list = await repository.GetIssuesCancelledInDateRangeByIssueTypeAsync(IssueTypes.Bug, DataMock.INT_ID_1, DataMock.DATETIME_LAST_CYCLE_INIT, DataMock.DATETIME_LAST_CYCLE_END, GetCancellationToken());

            list.Should().HaveCount(0);
        }

        [Fact(DisplayName = "[IssueRepository.GetIssuesCreatedAndResolvedInDateRangeByIssueTypeAsync] Deve listar todas as issues que foram criadas e resolvidas no período e do tipo informado.")]
        public async void DeveListarIssueCriadasEResolvidasNoPeriodoETipo()
        {
            var list = await repository.GetIssuesCreatedAndResolvedInDateRangeByIssueTypeAsync(IssueTypes.Bug, DataMock.INT_ID_1, DataMock.DATETIME_LAST_CYCLE_INIT, DataMock.DATETIME_LAST_CYCLE_END, GetCancellationToken());

            list.Should().HaveCount(0);
        }

        [Fact(DisplayName = "[IssueRepository.GetIssuesCreatedInDateRangeByIssueTypeAsync] Deve listar todas as issues que foram criadas no período e do tipo informado.")]
        public async void DeveListarIssueCriadasNoPeriodoETipo()
        {
            var list = await repository.GetIssuesCreatedInDateRangeByIssueTypeAsync(IssueTypes.Bug, DataMock.INT_ID_1, DataMock.DATETIME_LAST_CYCLE_INIT, DataMock.DATETIME_LAST_CYCLE_END, GetCancellationToken());

            list.Should().HaveCount(1);
        }

        [Fact(DisplayName = "[IssueRepository.GetIssuesExistedInDateRangeByIssueTypeAsync] Deve listar todas as issues em aberto herdadas dos quarters passados no período e do tipo informado.")]
        public async void DeveListarIssueExistentesNoPeriodoETipo()
        {
            var list = await repository.GetIssuesExistedInDateRangeByIssueTypeAsync(IssueTypes.Bug, DataMock.INT_ID_1, DataMock.DATETIME_LAST_CYCLE_INIT, DataMock.DATETIME_LAST_CYCLE_END, GetCancellationToken());

            list.Should().HaveCount(0);
        }

        [Fact(DisplayName = "[IssueRepository.GetIssuesOpenedInDateRangeByIssueTypeAsync] Deve listar todas as issues que estão em aberto no período e do tipo informado.")]
        public async void DeveListarIssueEmAbertoNoPeriodoETipo()
        {
            var list = await repository.GetIssuesOpenedInDateRangeByIssueTypeAsync(IssueTypes.Bug, DataMock.INT_ID_1, DataMock.DATETIME_LAST_CYCLE_INIT, DataMock.DATETIME_LAST_CYCLE_END, GetCancellationToken());

            list.Should().HaveCount(0);
        }

        [Fact(DisplayName = "[IssueRepository.GetIssuesResolvedInDateRangeByIssueTypeAsync] Deve listar todas as issues que foram resolvidas no período e do tipo informado.")]
        public async void DeveListarIssueResolvidasNoPeriodoETipo()
        {
            var list = await repository.GetIssuesResolvedInDateRangeByIssueTypeAsync(IssueTypes.Bug, DataMock.INT_ID_1, DataMock.DATETIME_LAST_CYCLE_INIT, DataMock.DATETIME_LAST_CYCLE_END, GetCancellationToken());

            list.Should().HaveCount(0);
        }
    }
}