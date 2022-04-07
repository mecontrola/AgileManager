using System.Net;
using WireMock.RequestBuilders;
using WireMock.Server;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Server.Settings
{
    public class ExceptionApiMock : BaseSettingsMock
    {
        private const string URL_QUERY_PARAM_NAME = "status";

        public override void Create(WireMockServer server)
        {
            server.Given(CreateRequestUnauthorized(HttpStatusCode.NoContent))
                  .RespondWith(ResponseBuild(HttpStatusCode.NoContent));

            server.Given(CreateRequestUnauthorized(HttpStatusCode.Unauthorized))
                  .RespondWith(ResponseBuild(HttpStatusCode.Unauthorized));

            server.Given(CreateRequestUnauthorized(HttpStatusCode.Forbidden))
                  .RespondWith(ResponseBuild(HttpStatusCode.Forbidden));

            server.Given(CreateRequestUnauthorized(HttpStatusCode.RequestTimeout))
                  .RespondWith(ResponseBuild(HttpStatusCode.RequestTimeout));
        }

        private static IRequestBuilder CreateRequestUnauthorized(HttpStatusCode httpStatusCode)
            => RequestGetBuild(GetRouteBase()).WithParam(URL_QUERY_PARAM_NAME, $"{(int)httpStatusCode}");

        private static string GetRouteBase()
            => DataMock.ISSUE_SELF_1.Replace(DataMock.JIRA_HOST, string.Empty);
    }
}