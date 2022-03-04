using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using route = Stefanini.ViaReport.Core.Integrations.Jira.Routes.ApiRoute;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Server.Settings
{
    public class IssueGetMock : BaseSettingsMock
    {
        private const string JSON_FILE_NAME = "issue.get.SEA-242.json";
        private const string URL_QUERY_PARAM_NAME = "expand";
        private const string URL_QUERY_PARAM_VALUE = "changelog";
        private const string KEY_URL_TO_REPLACE = "{issueKey}?expand=changelog";

        public override void Create(WireMockServer server)
            => server.Given(CreateRequest())
                     .RespondWith(CreateResponse());

        private static IRequestBuilder CreateRequest()
            => RequestGetBuild(route.Issue
                                    .GET
                                    .Replace(KEY_URL_TO_REPLACE,
                                             DataMock.TEXT_KEY_ISSUE_SEA242))
            .WithParam(URL_QUERY_PARAM_NAME, URL_QUERY_PARAM_VALUE);

        private static IResponseBuilder CreateResponse()
            => ResponseBuild(JSON_FILE_NAME);
    }
}