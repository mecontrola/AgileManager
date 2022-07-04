using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Core.Tests.Mocks;
using Stefanini.ViaReport.Core.Tests.Mocks.Repositories;
using Stefanini.ViaReport.DataStorage.Repositories;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.DataStorage.Repositories
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