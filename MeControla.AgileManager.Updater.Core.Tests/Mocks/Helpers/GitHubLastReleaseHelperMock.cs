using NSubstitute;
using MeControla.AgileManager.Updater.Core.Data.Dtos;
using MeControla.AgileManager.Updater.Core.Helpers;
using MeControla.AgileManager.Updater.Core.Tests.Mocks.Dtos;
using System.Threading;

namespace MeControla.AgileManager.Updater.Core.Tests.Mocks.Helpers
{
    public class GitHubLastReleaseHelperMock
    {
        public static IGitHubLastReleaseHelper Create()
            => CreateMockWithReturn(ReleaseDtoMock.Create());

        public static IGitHubLastReleaseHelper CreateWithInvalidVersion()
            => CreateMockWithReturn(ReleaseDtoMock.CreateInvalidVersion());

        public static IGitHubLastReleaseHelper CreateWithNullVersion()
            => CreateMockWithReturn(ReleaseDtoMock.CreateNullVersion());

        public static IGitHubLastReleaseHelper CreateWithNullReturn()
            => CreateMockWithReturn(null);

        private static IGitHubLastReleaseHelper CreateMockWithReturn(ReleaseDto releaseDto)
        {
            var mock = Substitute.For<IGitHubLastReleaseHelper>();
            mock.GetLastRelease(Arg.Any<CancellationToken>())
                .Returns(releaseDto);

            return mock;
        }
    }
}