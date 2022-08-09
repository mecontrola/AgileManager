using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using route = MeControla.AgileManager.Core.Integrations.Jira.Routes.ApiRoute;

namespace MeControla.AgileManager.Core.Tests.Mocks.Server.Settings
{
    public class SearchPostMock : BaseSettingsMock
    {
        private const string JSON_FILE_NAME = "search.post.all.json";

        public override void Create(WireMockServer server)
            => server.Given(CreateRequest())
                     .RespondWith(CreateResponse());

        private static IRequestBuilder CreateRequest()
            => RequestPostBuild(route.Search.POST);

        private static IResponseBuilder CreateResponse()
            => ResponseBuild(JSON_FILE_NAME);
    }
}