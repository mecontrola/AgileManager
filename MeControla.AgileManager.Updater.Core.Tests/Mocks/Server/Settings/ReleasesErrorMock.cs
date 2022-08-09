using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace MeControla.AgileManager.Updater.Core.Tests.Mocks.Server.Settings
{
    public class ReleasesErrorMock : BaseSettingsMock
    {
        private const string JSON_FILE_NAME = "releases.error.json";

        public override void Create(WireMockServer server)
            => server.Given(CreateRequest())
                     .RespondWith(CreateResponse());

        private static IRequestBuilder CreateRequest()
            => RequestGetBuild(DataMock.URL_EXCEPTION);

        private static IResponseBuilder CreateResponse()
            => ResponseBuild(JSON_FILE_NAME);
    }
}