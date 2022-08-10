using FluentAssertions;
using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Updater.Core.Exceptions;
using MeControla.AgileManager.Updater.Core.Helpers;
using MeControla.AgileManager.Updater.Core.Tests.Mocks;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.AgileManager.Updater.Core.Tests.Helpers
{
    public class Step01HelperTests : BaseAsyncMethods
    {
        private readonly IStep01Helper helper;

        private readonly ILocalVersionHelper localVersionHelper;
        private readonly IRemoteVersionHelper remoteVersionHelper;

        private readonly Version actualVersion = new(1, 0, 0, 2);

        public Step01HelperTests()
        {
            localVersionHelper = Substitute.For<ILocalVersionHelper>();
            localVersionHelper.GetVersion().Returns(x => actualVersion);

            remoteVersionHelper = Substitute.For<IRemoteVersionHelper>();
            remoteVersionHelper.GetVersion(Arg.Any<CancellationToken>()).Returns(x => DataMock.VERSION_GITHUB);

            helper = new Step01Helper(localVersionHelper, remoteVersionHelper);
        }

        [Fact(DisplayName = "[Step01Helper.Run] Deve gerar exceção quando não for encontrada a versão do aplicativo instalado.")]
        public async void DeveGerarExcepcaoQuandoLocalVersionNull()
        {
            localVersionHelper.GetVersion().Returns(x => null);

            var action = () => helper.Run(GetCancellationToken());

            await action.Should().ThrowAsync<UpdateNotFoundException>();
        }

        [Fact(DisplayName = "[Step01Helper.Run] Deve gerar exceção quando não for encontrada a versão do disponível no github.")]
        public async void DeveGerarExcepcaoQuandoRemotoVersionNull()
        {
            remoteVersionHelper.GetVersion(Arg.Any<CancellationToken>()).Returns(x => Task.FromResult<Version>(null));

            var action = () => helper.Run(GetCancellationToken());

            await action.Should().ThrowAsync<UpdateNotFoundException>();
        }

        [Fact(DisplayName = "[Step01Helper.Run] Deve gerar exceção quando a verssão local for igual a existente no github.")]
        public async void DeveGerarExcepcaoQuandoVersaoRemotaLocalIguais()
        {
            remoteVersionHelper.GetVersion(Arg.Any<CancellationToken>()).Returns(x => actualVersion);

            var action = () => helper.Run(GetCancellationToken());

            await action.Should().ThrowAsync<UpdateNotFoundException>();
        }

        [Fact(DisplayName = "[Step01Helper.Run] Deve confirmar a existência de uma nova versão e não gerar exceção para interromper a rotina.")]
        public async void DeveConfirmarExistenciaVersaoSemGerarExcecao()
        {
            var action = () => helper.Run(GetCancellationToken());

            await action.Should().NotThrowAsync<UpdateNotFoundException>();
        }
    }
}