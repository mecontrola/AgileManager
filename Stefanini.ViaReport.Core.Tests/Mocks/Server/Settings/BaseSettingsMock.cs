using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;
using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Server.Settings
{
    public abstract class BaseSettingsMock
    {
        public abstract void Create(WireMockServer server);

        protected static IRequestBuilder RequestGetBuild(string url)
            => Request.Create().WithPath(url).UsingGet();

        protected static IRequestBuilder RequestPostBuild(string url)
            => Request.Create().WithPath(url).UsingPost();

        protected static IResponseBuilder ResponseBuild(string filename)
            => Response.Create()
                       .WithHeader("Content-Type", "application/json")
                       .WithStatusCode(200)
                       .WithBody(ApiUtilMockHelper.ReadJsonFile(filename))
                       .WithTransformer();

        protected static IResponseBuilder ResponseBuild(HttpStatusCode httpStatusCode)
            => Response.Create()
                       .WithHeader("Content-Type", "application/json")
                       .WithStatusCode(httpStatusCode);
    }
}