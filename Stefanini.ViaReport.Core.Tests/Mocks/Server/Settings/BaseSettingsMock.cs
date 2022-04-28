using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;
using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Server.Settings
{
    public abstract class BaseSettingsMock
    {
        private const string HEADER_CONTENT_TYPE_NAME = "Content-Type";
        private const string HEADER_CONTENT_TYPE_VALUE = "application/json";
        public abstract void Create(WireMockServer server);

        protected static IRequestBuilder RequestGetBuild(string url)
            => Request.Create().WithPath(url).UsingGet();

        protected static IRequestBuilder RequestPostBuild(string url)
            => Request.Create().WithPath(url).UsingPost();

        protected static IResponseBuilder ResponseBuild(string filename)
            => Response.Create()
                       .WithHeader(HEADER_CONTENT_TYPE_NAME, HEADER_CONTENT_TYPE_VALUE)
                       .WithStatusCode(200)
                       .WithBody(ApiUtilMockHelper.ReadJsonFile(filename))
                       .WithTransformer();

        protected static IResponseBuilder ResponseBuild(HttpStatusCode httpStatusCode)
            => Response.Create()
                       .WithHeader(HEADER_CONTENT_TYPE_NAME, HEADER_CONTENT_TYPE_VALUE)
                       .WithStatusCode(httpStatusCode);
    }
}