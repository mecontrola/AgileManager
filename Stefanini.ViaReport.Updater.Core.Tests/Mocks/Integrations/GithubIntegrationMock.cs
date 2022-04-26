using Stefanini.ViaReport.Updater.Core.Data.Configurations;
using Stefanini.ViaReport.Updater.Core.Integrations.Github;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Tests.Mocks.Integrations
{
    public class GithubIntegrationMock : BaseGithubIntegration
    {
        public GithubIntegrationMock(IUpdaterConfiguration updaterConfiguration)
            : base(updaterConfiguration, new JsonSnakeCaseNamingPolicy())
        { }

        public async Task<string> Execute(HttpStatusCode httpStatusCode, CancellationToken cancellationToken)
        {
            URL = $"{GetRouteBase()}?status={(int)httpStatusCode}";

            return await GetAsync<string>(cancellationToken);
        }

        public async Task<string> ExecuteJsonError(CancellationToken cancellationToken)
        {
            URL = $"{GetRouteBase()}?status=json";

            return await GetAsync<string>(cancellationToken);
        }

        private static string GetRouteBase()
            => DataMock.URL_EXCEPTION;
    }
}