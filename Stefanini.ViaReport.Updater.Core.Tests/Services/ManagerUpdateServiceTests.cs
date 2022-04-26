using NSubstitute;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Updater.Core.Exceptions;
using Stefanini.ViaReport.Updater.Core.Helpers;
using Stefanini.ViaReport.Updater.Core.Services;
using Stefanini.ViaReport.Updater.Core.Tests.Data.Utils;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Utils;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Stefanini.ViaReport.Updater.Core.Tests.Services
{
    public class ManagerUpdateServiceTests : BaseAsyncMethods
    {
        private readonly IManagerUpdateService service;

        private readonly IStep01Helper step01Helper;
        private readonly IStep02Helper step02Helper;
        private readonly IStep03Helper step03Helper;
        private readonly IStep04Helper step04Helper;

        private readonly IActionUpdate actions;

        public ManagerUpdateServiceTests()
        {
            actions = ActionUpdateMock.Create();

            step01Helper = Substitute.For<IStep01Helper>();
            step02Helper = Substitute.For<IStep02Helper>();
            step03Helper = Substitute.For<IStep03Helper>();
            step04Helper = Substitute.For<IStep04Helper>();

            service = new ManagerUpdateService(step01Helper, step02Helper, step03Helper, step04Helper);
        }

        [Fact(DisplayName = "[ManagerUpdateService.CheckAndDownloadUpdate] Deve finalizar atualização quando não encontrar atuzalição.")]
        public async Task DeveFinalizarQuandoVersaoNaoEncontrada()
        {
            step01Helper.Run(GetCancellationToken()).Returns(x => { throw new UpdateNotFoundException(); });

            var actions = ActionUpdateMock.Create();

            await service.CheckAndDownloadUpdate(actions.UpdateStatus, actions.UpdateProgress, GetCancellationToken());

            actions.Received(1).UpdateStatus(Arg.Any<string>());
            actions.Received(1).UpdateProgress(Arg.Any<bool>(), Arg.Any<long>());
        }

        [Fact(DisplayName = "[ManagerUpdateService.CheckAndDownloadUpdate] Deve finalizar atualização quando não encontrar atuzalição.")]
        public async Task DeveFinalizarQuandoErroMatarProcesso()
        {
            step02Helper.When(x => x.Run()).Do(x => { throw new SystemException(); });

            await service.CheckAndDownloadUpdate(actions.UpdateStatus, actions.UpdateProgress, GetCancellationToken());

            actions.Received(2).UpdateStatus(Arg.Any<string>());
            actions.Received(2).UpdateProgress(Arg.Any<bool>(), Arg.Any<long>());
        }

        [Fact(DisplayName = "[ManagerUpdateService.CheckAndDownloadUpdate] Deve finalizar atualização quando ocorrer erro ao baixar atualização.")]
        public async Task DeveFinalizarQuandoErroBaixarAtualizacao()
        {
            step03Helper.Run(actions.UpdateProgress, GetCancellationToken()).Returns(x => { throw new HttpRequestException(); });

            await service.CheckAndDownloadUpdate(actions.UpdateStatus, actions.UpdateProgress, GetCancellationToken());

            actions.Received(3).UpdateStatus(Arg.Any<string>());
            actions.Received(3).UpdateProgress(Arg.Any<bool>(), Arg.Any<long>());
        }

        [Fact(DisplayName = "[ManagerUpdateService.CheckAndDownloadUpdate] Deve finalizar atualização quando não encontrar atualização baixada para descompatar.")]
        public async Task DeveFinalizarQuandoNaoEncontrarArquivoAtualizacao()
        {
            step04Helper.When(x => x.Run()).Do(x => { throw new FileNotFoundException(); });

            await service.CheckAndDownloadUpdate(actions.UpdateStatus, actions.UpdateProgress, GetCancellationToken());

            actions.Received(4).UpdateStatus(Arg.Any<string>());
            actions.Received(4).UpdateProgress(Arg.Any<bool>(), Arg.Any<long>());
        }

        [Fact(DisplayName = "[ManagerUpdateService.CheckAndDownloadUpdate] Deve finalizar atualização quando concluir atualização.")]
        public async Task DeveFinalizarQuandoAtualizarAplicacao()
        {
            await service.CheckAndDownloadUpdate(actions.UpdateStatus, actions.UpdateProgress, GetCancellationToken());

            actions.Received(5).UpdateStatus(Arg.Any<string>());
            actions.Received(5).UpdateProgress(Arg.Any<bool>(), Arg.Any<long>());
        }
    }
}