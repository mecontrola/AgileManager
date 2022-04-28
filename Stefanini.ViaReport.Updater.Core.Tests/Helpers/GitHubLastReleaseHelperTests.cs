using FluentAssertions;
using Stefanini.Core.TestingTools;
using Stefanini.ViaReport.Updater.Core.Helpers;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Dtos;
using Stefanini.ViaReport.Updater.Core.Tests.Mocks.Integrations.Github.Repos;
using Xunit;

namespace Stefanini.ViaReport.Updater.Core.Tests.Helpers
{
    public class GitHubLastReleaseHelperTests : BaseAsyncMethods
    {
        [Fact(DisplayName = "[GitHubLastReleaseHelper.GetLastRelease] Deve retornar ReleaseDto quando consumir API e existir retorno.")]
        public async void DeveRetornarDtoQuandoNaoTiverErro()
        {
            var api = ReleasesLastestMock.Create();
            var helper = new GitHubLastReleaseHelper(api);

            var expected = ReleaseDtoMock.Create();
            var actual = await helper.GetLastRelease(GetCancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[GitHubLastReleaseHelper.GetLastRelease] Deve retornar null quando ocorrer erro ao consumir API.")]
        public async void DeveRetornarNullQuandoOcorrerErro()
        {
            var api = ReleasesLastestMock.CreateWithGithubException();
            var helper = new GitHubLastReleaseHelper(api);

            var actual = await helper.GetLastRelease(GetCancellationToken());
            actual.Should().BeNull();
        }
    }
}