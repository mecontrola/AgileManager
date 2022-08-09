using MeControla.AgileManager.Updater.Core.Tests.TestUtils.Helpers;
using System.Collections.Generic;
using System.Net;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace MeControla.AgileManager.Updater.Core.Tests.Mocks.Server.Settings
{
    public abstract class BaseSettingsMock
    {
        private const string HEADER_CONTENT_LENGTH_NAME = "Content-Length";
        private const string HEADER_CONTENT_TYPE_NAME = "Content-Type";
        private const string HEADER_CONTENT_TYPE_JSON_VALUE = "application/json";
        private const string HEADER_CONTENT_TYPE_XML_VALUE = "text/xml";

        public abstract void Create(WireMockServer server);

        protected static IRequestBuilder RequestGetBuild(string url)
            => Request.Create().WithPath(url).UsingGet();

        protected static IResponseBuilder ResponseBuild(string filename)
            => Response.Create()
                       .WithHeader(HEADER_CONTENT_TYPE_NAME, HEADER_CONTENT_TYPE_JSON_VALUE)
                       .WithStatusCode(HttpStatusCode.OK)
                       .WithBody(ApiUtilMockHelper.ReadJsonFile(filename))
                       .WithTransformer();

        protected static IResponseBuilder ResponseDownloadBuild(string filename)
        {
            var filecontent = ApiUtilMockHelper.ReadDownloadFile(filename);

            return Response.Create()
                           .WithHeaders(new Dictionary<string, string>
                           {
                               { HEADER_CONTENT_TYPE_NAME, HEADER_CONTENT_TYPE_XML_VALUE },
                               { HEADER_CONTENT_LENGTH_NAME, filecontent.Length.ToString() },
                               { "Transfer-Encoding", "identity" }
                           })
                           .WithStatusCode(HttpStatusCode.OK)
                           .WithBody(filecontent);
        }

        protected static IResponseBuilder ResponseBuild(HttpStatusCode httpStatusCode)
            => Response.Create()
                       .WithHeader(HEADER_CONTENT_TYPE_NAME, HEADER_CONTENT_TYPE_JSON_VALUE)
                       .WithStatusCode(httpStatusCode);
    }
}