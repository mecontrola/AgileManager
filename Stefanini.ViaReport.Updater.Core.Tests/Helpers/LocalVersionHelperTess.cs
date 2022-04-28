using FluentAssertions;
using NSubstitute;
using Stefanini.ViaReport.Updater.Core.Data.Configurations;
using Stefanini.ViaReport.Updater.Core.Helpers;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks;
using System.IO;
using Xunit;

namespace Stefanini.ViaReport.Updater.Core.Tests.Helpers
{
    public class LocalVersionHelperTess
    {
        private readonly ILocalVersionHelper helper;
        private readonly IToolsHelper toolsHelper;

        public LocalVersionHelperTess()
        {
            toolsHelper = Substitute.For<IToolsHelper>();
            toolsHelper.GetFileVersion(Arg.Any<string>()).Returns(DataMock.VERSION_GITHUB.ToString());

            var updaterConfiguration = Substitute.For<IUpdaterConfiguration>();
            helper = new LocalVersionHelper(updaterConfiguration, toolsHelper);
        }

        [Fact(DisplayName = "[LocalVersionHelper.GetVersion] Deve retornar null quando aplicativo não for encontrado.")]
        public void DeveRetornarNullQuandoAplicativoNaoEncontrado()
        {
            toolsHelper.GetFileVersion(Arg.Any<string>()).Returns(x => { throw new FileNotFoundException(); });

            helper.GetVersion().Should().BeNull();
        }

        [Fact(DisplayName = "[LocalVersionHelper.GetVersion] Deve retornar null quando aplicativo não tiver o atributo FileVersion.")]
        public void DeveRetornarNullQuandoAplicativoNaoTiverAtributoFileVersion()
        {
            toolsHelper.GetFileVersion(Arg.Any<string>()).Returns((string)null);

            helper.GetVersion().Should().BeNull();
        }

        [Fact(DisplayName = "[LocalVersionHelper.GetVersion] Deve retornar Version quando aplicativo tiver o atributo FileVersion.")]
        public void DeveRetornarVersionQuandoAplicativoTiverAtributoFileVersion()
        {
            var expected = DataMock.VERSION_GITHUB;
            var actual = helper.GetVersion();

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}