using FluentAssertions;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Repositories;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.TestingTools;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.DataStorage.Repositories
{
    public class IssueTypeRepositoryTests : BaseAsyncMethods
    {
        private readonly IIssueTypeRepository repository;

        public IssueTypeRepositoryTests()
        {
            repository = IssueTypeRepositoryMock.Create();
        }

        [Fact(DisplayName = "[IssueTypeRepository.FindByKeyAsync] Deve retornar issue type quando campo Key válido.")]
        public async void DeveRetornarIssueTypeQuandoCampoKeyValido()
        {
            var actual = await repository.FindByKeyAsync(DataMock.KEY_ISSUE_TYPE, GetCancellationToken());

            actual.Name.Should().BeEquivalentTo(DataMock.NAME_ISSUE_TYPE);
        }

        [Fact(DisplayName = "[IssueTypeRepository.FindByKeyAsync] Deve retornar null quando campo Key inválido.")]
        public async void DeveRetornarNullQuandoCampoKeyInvalido()
        {
            var actual = await repository.FindByKeyAsync(DataMock.KEY_NOT_FOUND, GetCancellationToken());

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[StatusCategoryRepository.ExistsByKeyAsync] Deve retornar true quando campo Key informado foi de um issue type válido.")]
        public async void DeveRetornarTrueQuandoCampoKeyDeStatusCategoryValido()
        {
            var actual = await repository.ExistsByKeyAsync(DataMock.KEY_ISSUE_TYPE, GetCancellationToken());

            actual.Should().BeTrue();
        }

        [Fact(DisplayName = "[StatusCategoryRepository.ExistsByKeyAsync] Deve retornar false quando campo Key informado foi de um issue type inválido.")]
        public async void DeveRetornarFalseQuandoCampoKeyDeStatusCategoryInvalido()
        {
            var actual = await repository.ExistsByKeyAsync(DataMock.KEY_NOT_FOUND, GetCancellationToken());

            actual.Should().BeFalse();
        }
    }
}