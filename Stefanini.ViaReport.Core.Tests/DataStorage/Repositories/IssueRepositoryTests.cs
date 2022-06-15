using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Repositories;
using Stefanini.ViaReport.DataStorage.Repositories;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.DataStorage.Repositories
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
            var actual = await repository.FindByKeyAsync(DataMock.KEY_ISSUE, GetCancellationToken());

            actual.Summary.Should().BeEquivalentTo(DataMock.SUMMARY_ISSUE_TYPE);
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

            actual.Should().NotBeNull();
            actual.Value.Should().Be(DataMock.UPDATED_ISSUE);
        }

        [Fact(DisplayName = "[IssueRepository.GetLastUpdated] Deve retornar null quando campo projectId inválido.")]
        public async void DeveRetornarNullRecenteQuandoCampoProjectIdInvalido()
        {
            var actual = await repository.GetLastUpdatedAsync(DataMock.ID_NOT_FOUND, GetCancellationToken());

            actual.Should().BeNull();
        }
    }
}