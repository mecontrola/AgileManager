using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Repositories;
using Stefanini.ViaReport.DataStorage.Repositories;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.DataStorage.Repositories
{
    public class StatusCategoryRepositoryTests : BaseAsyncMethods
    {
        private readonly IStatusCategoryRepository repository;

        public StatusCategoryRepositoryTests()
        {
            repository = StatusCategoryRepositoryMock.Create();
        }

        [Fact(DisplayName = "[StatusCategoryRepository.FindByKeyAsync] Deve retornar status category quando campo Key válido.")]
        public async void DeveRetornarStatusCategoryQuandoCampoKeyValido()
        {
            var actual = await repository.FindByKeyAsync(DataMock.KEY_STATUS_CATEGORY, GetCancellationToken());

            actual.Name.Should().BeEquivalentTo(DataMock.NAME_STATUS_CATEGORY);
        }

        [Fact(DisplayName = "[StatusCategoryRepository.FindByKeyAsync] Deve retornar null quando campo Key inválido.")]
        public async void DeveRetornarNullQuandoCampoKeyInvalido()
        {
            var actual = await repository.FindByKeyAsync(DataMock.KEY_NOT_FOUND, GetCancellationToken());

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[StatusCategoryRepository.ExistsByKeyAsync] Deve retornar true quando campo Key informado foi de um status category válido.")]
        public async void DeveRetornarTrueQuandoCampoKeyDeStatusCategoryValido()
        {
            var actual = await repository.ExistsByKeyAsync(DataMock.KEY_STATUS_CATEGORY, GetCancellationToken());

            actual.Should().BeTrue();
        }

        [Fact(DisplayName = "[StatusCategoryRepository.ExistsByKeyAsync] Deve retornar false quando campo Key informado foi de um status category inválido.")]
        public async void DeveRetornarFalseQuandoCampoKeyDeStatusCategoryInvalido()
        {
            var actual = await repository.ExistsByKeyAsync(DataMock.KEY_NOT_FOUND, GetCancellationToken());

            actual.Should().BeFalse();
        }
    }
}