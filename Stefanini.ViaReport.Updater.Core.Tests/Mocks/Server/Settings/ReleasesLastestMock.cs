using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using route = Stefanini.ViaReport.Updater.Core.Integrations.Github.Routes.ApiRoute;

namespace Stefanini.ViaReport.Updater.Core.Tests.Mocks.Server.Settings
{
    public class ReleasesLastestMock : BaseSettingsMock
    {
        private const string JSON_FILE_NAME = "releases.lastest.json";

        public override void Create(WireMockServer server)
            => server.Given(CreateRequest())
                     .RespondWith(CreateResponse());

        private static IRequestBuilder CreateRequest()
            => RequestGetBuild(route.Releases.LASTEST);

        private static IResponseBuilder CreateResponse()
            => ResponseBuild(JSON_FILE_NAME);
    }
}