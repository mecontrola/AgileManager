using NSubstitute;
using Stefanini.ViaReport.Updater.Core.Data.Configurations;
using Stefanini.ViaReport.Updater.Core.Helpers;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Configurations;
using System;
using Xunit;

namespace Stefanini.ViaReport.Updater.Core.Tests.Helpers
{
    public class Step04HelperTests
    {
        private readonly IUpdaterConfiguration updaterConfiguration;
        private readonly IToolsHelper toolsHelper;

        private readonly IStep04Helper helper;

        public Step04HelperTests()
        {
            updaterConfiguration = UpdaterConfigurationMock.Create();
            toolsHelper = Substitute.For<IToolsHelper>();

            helper = new Step04Helper(updaterConfiguration,
                                      toolsHelper);
        }

        [Fact(DisplayName = "[Step04Helper.Run] Deve finalizar a rotina quando o arquivo baixado não for encontrado.")]
        public void DeveFinalizarQuandoArquivoNaoEncontrado()
        {
            toolsHelper.FileExists(Arg.Any<string>()).Returns(false);

            helper.Run();

            toolsHelper.Received(1).FileExists(Arg.Is<string>(x => x.Equals(DataMock.STRING_RENAME_FILE_DOWNLOADED)));
            toolsHelper.Received(0).ZipExtractOverride(Arg.Is<string>(x => x.Equals(DataMock.STRING_RENAME_FILE_DOWNLOADED)),
                                                       Arg.Is<string>(x => x.Equals(AppContext.BaseDirectory)));
            toolsHelper.Received(0).FileDelete(Arg.Is<string>(x => x.Equals(DataMock.STRING_RENAME_FILE_DOWNLOADED)));
        }

        [Fact(DisplayName = "[Step04Helper.Run] Deve extrair o arquivo de atualização com a nova versão e remover o arquivo na sequência.")]
        public void DeveExtrairAtualizacaoExcluirArquivoBaixado()
        {
            toolsHelper.FileExists(Arg.Any<string>()).Returns(true);

            helper.Run();

            toolsHelper.Received(1).FileExists(Arg.Is<string>(x => x.Equals(DataMock.STRING_RENAME_FILE_DOWNLOADED)));
            toolsHelper.Received(1).ZipExtractOverride(Arg.Is<string>(x => x.Equals(DataMock.STRING_RENAME_FILE_DOWNLOADED)),
                                                       Arg.Is<string>(x => x.Equals(AppContext.BaseDirectory)));
            toolsHelper.Received(1).FileDelete(Arg.Is<string>(x => x.Equals(DataMock.STRING_RENAME_FILE_DOWNLOADED)));
        }
    }
}