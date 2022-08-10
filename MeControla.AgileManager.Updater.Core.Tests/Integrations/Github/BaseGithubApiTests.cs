using MeControla.AgileManager.TestingTools;
using MeControla.AgileManager.Updater.Core.Data.Configurations;
using MeControla.AgileManager.Updater.Core.Tests.Mocks.Server.Settings;

namespace MeControla.AgileManager.Updater.Core.Tests.Integrations.Github
{
    public abstract class BaseGithubApiTests : BaseTestApi
    {
        private readonly DownloadFileMock downloadFileMock = new();
        private readonly ExceptionApiMock exceptionApiMock = new();
        private readonly ReleasesErrorMock releasesErrorMock = new();
        private readonly ReleasesLastestMock releasesLastestMock = new();

        public BaseGithubApiTests()
            : base()
        { }

        protected void ConfigureDownloadFile()
            => downloadFileMock.Create(server);

        protected void ConfigureReleasesError()
            => releasesErrorMock.Create(server);

        protected void ConfigureReleasesLastest()
            => releasesLastestMock.Create(server);

        protected void ConfigureExceptionApi()
            => exceptionApiMock.Create(server);

        protected IUpdaterConfiguration GetConfiguration()
            => new UpdaterConfiguration
            {
                GitUrl = GetServerUrl(),
            };

        protected string GetServerUrl()
            => server.Urls[0];
    }
}