using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using route = MeControla.AgileManager.Integrations.Jira.Routes.ApiRoute;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Server.Settings
{
    public class StatusGetAllMock : BaseSettingsMock
    {
        private const string JSON_FILE_NAME = "status.get.all.json";

        public override void Create(WireMockServer server)
            => server.Given(CreateRequest())
                     .RespondWith(CreateResponse());

        private static IRequestBuilder CreateRequest()
            => RequestGetBuild(route.Status.GET_ALL);

        private static IResponseBuilder CreateResponse()
            => ResponseBuild(JSON_FILE_NAME);
    }
}