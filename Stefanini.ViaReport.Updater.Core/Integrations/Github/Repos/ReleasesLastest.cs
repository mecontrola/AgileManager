using Stefanini.ViaReport.Updater.Core.Data.Configurations;
using Stefanini.ViaReport.Updater.Core.Data.Dtos;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using route = Stefanini.ViaReport.Updater.Core.Integrations.Github.Routes.ApiRoute.Releases;

namespace Stefanini.ViaReport.Updater.Core.Integrations.Github.Repos
{
    public class ReleasesLastest : BaseGithubIntegration, IReleasesLastest
    {
        public ReleasesLastest(IUpdaterConfiguration updaterConfiguration)
            : base(updaterConfiguration, new JsonSnakeCaseNamingPolicy())
        { }

        public async Task<ReleaseDto> Execute(CancellationToken cancellationToken)
        {
            URL = route.LASTEST;

            return await GetAsync<ReleaseDto>(cancellationToken);
        }
    }
}