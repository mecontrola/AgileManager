using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Updater.Core.Helpers;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Helpers;
using Xunit;

namespace Stefanini.ViaReport.Updater.Core.Tests.Helpers
{
    public class RemoteVersionHelperTests : BaseAsyncMethods
    {
        [Fact(DisplayName = "[RemoteVersionHelper.GetVersion] Deve retornar null quando o retorno da API for null.")]
        public async void DeveRetornarNullQuandoApiRetornarNull()
        {
            var api = GitHubLastReleaseHelperMock.CreateWithNullReturn();
            var helper = new RemoteVersionHelper(api);

            var actual = await helper.GetVersion(GetCancellationToken());

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[RemoteVersionHelper.GetVersion] Deve retornar null quando o retorno da versão da última release for invalida.")]
        public async void DeveRetornarNullQuandoApiRetornarVersaoInvalida()
        {
            var api = GitHubLastReleaseHelperMock.CreateWithInvalidVersion();
            var helper = new RemoteVersionHelper(api);

            var actual = await helper.GetVersion(GetCancellationToken());

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[RemoteVersionHelper.GetVersion] Deve retornar null quando o retorno da versão da última release for null.")]
        public async void DeveRetornarNullQuandoApiRetornarVersaoNull()
        {
            var api = GitHubLastReleaseHelperMock.CreateWithNullVersion();
            var helper = new RemoteVersionHelper(api);

            var actual = await helper.GetVersion(GetCancellationToken());

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[RemoteVersionHelper.GetVersion] Deve retornar Version da última release quando a API retornar a última release publicada.")]
        public async void DeveRetornarVersaoQuandoApiRetornarRelease()
        {
            var api = GitHubLastReleaseHelperMock.Create();
            var helper = new RemoteVersionHelper(api);

            var expected = DataMock.VERSION_GITHUB;
            var actual = await helper.GetVersion(GetCancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }
    }
}