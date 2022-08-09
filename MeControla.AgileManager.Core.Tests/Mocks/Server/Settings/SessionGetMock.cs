using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.AuthRoute;

namespace MeControla.AgileManager.Core.Tests.Mocks.Server.Settings
{
    public class SessionGetMock : BaseSettingsMock
    {
        private const string JSON_FILE_NAME = "session.get.json";

        public override void Create(WireMockServer server)
            => server.Given(CreateRequest())
                     .RespondWith(CreateResponse());

        private static IRequestBuilder CreateRequest()
            => RequestGetBuild(route.Session.GET);

        private static IResponseBuilder CreateResponse()
            => ResponseBuild(JSON_FILE_NAME);
    }
}