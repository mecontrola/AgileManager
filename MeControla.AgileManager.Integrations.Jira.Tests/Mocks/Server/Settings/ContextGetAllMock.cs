using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using route = MeControla.AgileManager.Integrations.Jira.Routes.ApiRoute;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Server.Settings
{
    public class ContextGetAllMock : BaseSettingsMock
    {
        private const string JSON_FILE_NAME = "context.get.10181.json";

        public override void Create(WireMockServer server)
            => server.Given(CreateRequest())
                     .RespondWith(CreateResponse());

        private static IRequestBuilder CreateRequest()
            => RequestGetBuild(route.Context
                                    .GET_ALL
                                    .Replace(route.Context.PARAM_FIELD_ID,
                                             DataMock.FIELD_ID_CLASSES_OF_SERVICE));

        private static IResponseBuilder CreateResponse()
            => ResponseBuild(JSON_FILE_NAME);
    }
}