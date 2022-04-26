using NSubstitute;
using Stefanini.ViaReport.Updater.Core.Data.Configurations;
using Stefanini.ViaReport.Updater.Core.Extends.System.Diagnostics;
using Stefanini.ViaReport.Updater.Core.Helpers;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Configurations;
using Xunit;

namespace Stefanini.ViaReport.Updater.Core.Tests.Helpers
{
    public class Step02HelperTests
    {
        private readonly IUpdaterConfiguration updaterConfiguration;
        private readonly IToolsHelper toolsHelper;

        private readonly IWinProcess process;

        private readonly IStep02Helper helper;

        public Step02HelperTests()
        {
            process = Substitute.For<IWinProcess>();

            updaterConfiguration = UpdaterConfigurationMock.Create();
            toolsHelper = Substitute.For<IToolsHelper>();
            toolsHelper.FindProcessRunning(Arg.Any<string>()).Returns(process);

            helper = new Step02Helper(updaterConfiguration,
                                      toolsHelper);
        }

        [Fact(DisplayName = "[Step02Helper.Run] Deve finalizar a rotina quando o processo não for encontrado.")]
        public void DeveFinalizarQuandoProcessoNaoEncontrado()
        {
            toolsHelper.FindProcessRunning(Arg.Any<string>()).Returns((IWinProcess)null);

            helper.Run();

            toolsHelper.Received(1).FindProcessRunning(Arg.Is<string>(x => x.Equals(DataMock.STRING_APPLICATION_NAME)));
            process.Received(0).Kill();
            process.Received(0).WaitForExit();
            process.Received(0).Dispose();
        }

        [Fact(DisplayName = "[Step02Helper.Run] Deve finalizar o processo encontrado e prosseguir com a atualização.")]
        public void DeveFinalizarProcessoEncontrado()
        {
            helper.Run();

            toolsHelper.Received(1).FindProcessRunning(Arg.Is<string>(x => x.Equals(DataMock.STRING_APPLICATION_NAME)));
            process.Received(1).Kill();
            process.Received(1).WaitForExit();
            process.Received(1).Dispose();
        }
    }
}