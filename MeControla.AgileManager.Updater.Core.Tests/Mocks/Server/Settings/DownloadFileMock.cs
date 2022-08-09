using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace MeControla.AgileManager.Updater.Core.Tests.Mocks.Server.Settings
{
    public class DownloadFileMock : BaseSettingsMock
    {
        private const string XML_FILE_NAME = "file-to-download.xml";

        public override void Create(WireMockServer server)
            => server.Given(CreateRequest())
                     .RespondWith(CreateResponse());

        private static IRequestBuilder CreateRequest()
            => RequestGetBuild(DataMock.URL_DOWNLOAD_XML);

        private static IResponseBuilder CreateResponse()
            => ResponseDownloadBuild(XML_FILE_NAME);
    }
}