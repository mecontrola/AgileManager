using FluentAssertions;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Core.Tests.Mocks;
using MeControla.AgileManager.Core.Tests.Mocks.Repositories;
using MeControla.AgileManager.DataStorage.Repositories;
using Xunit;

namespace MeControla.AgileManager.Core.Tests.DataStorage.Repositories
{
    public class StatusRepositoryTests : BaseAsyncMethods
    {
        private readonly IStatusRepository repository;

        public StatusRepositoryTests()
        {
            repository = StatusRepositoryMock.Create();
        }

        [Fact(DisplayName = "[StatusRepository.ExistsByKeyAsync] Deve retornar true quando campo Key informado foi de um status válido.")]
        public async void DeveRetornarTrueQuandoCampoKeyDeStatusValido()
        {
            var actual = await repository.ExistsByKeyAsync(DataMock.KEY_STATUS, GetCancellationToken());

            actual.Should().BeTrue();
        }

        [Fact(DisplayName = "[StatusRepository.ExistsByKeyAsync] Deve retornar false quando campo Key informado foi de um status inválido.")]
        public async void DeveRetornarFalseQuandoCampoKeyDeStatusInvalido()
        {
            var actual = await repository.ExistsByKeyAsync(DataMock.KEY_NOT_FOUND, GetCancellationToken());

            actual.Should().BeFalse();
        }
    }
}