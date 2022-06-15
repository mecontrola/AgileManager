using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using route = Stefanini.ViaReport.Core.Integrations.Jira.Routes.ApiRoute;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Server.Settings
{
    public class IssueTypeGetMock : BaseSettingsMock
    {
        private const string JSON_FILE_NAME = "issuetype.get.all.json";

        public override void Create(WireMockServer server)
            => server.Given(CreateRequest())
                     .RespondWith(CreateResponse());

        private static IRequestBuilder CreateRequest()
            => RequestGetBuild(route.IssueType.GET_ALL);

        private static IResponseBuilder CreateResponse()
            => ResponseBuild(JSON_FILE_NAME);
    }
}