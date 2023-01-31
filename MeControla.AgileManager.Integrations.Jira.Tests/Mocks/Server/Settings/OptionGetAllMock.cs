using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using route = MeControla.AgileManager.Integrations.Jira.Routes.ApiRoute;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Server.Settings
{
    internal class OptionGetAllMock : BaseSettingsMock
    {
        private const string JSON_FILE_NAME = "option.get.all.10181.json";

        public override void Create(WireMockServer server)
            => server.Given(CreateRequest())
                     .RespondWith(CreateResponse());

        private static IRequestBuilder CreateRequest()
            => RequestGetBuild(route.Option
                                    .GET_ALL
                                    .Replace(route.Option.PARAM_FIELD_ID,
                                             DataMock.FIELD_ID_CLASSES_OF_SERVICE)
                                    .Replace(route.Option.PARAM_CONTEXT_ID,
                                             DataMock.CONTEXT_ID_DEFAULT));

        private static IResponseBuilder CreateResponse()
            => ResponseBuild(JSON_FILE_NAME);
    }
}