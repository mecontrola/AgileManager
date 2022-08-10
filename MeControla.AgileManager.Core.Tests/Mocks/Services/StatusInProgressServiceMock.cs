using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using NSubstitute;
using System.Threading;

namespace MeControla.AgileManager.Core.Tests.Mocks.Services
{
    public class StatusInProgressServiceMock
    {
        public static IStatusInProgressService Create()
        {
            var mock = Substitute.For<IStatusInProgressService>();
            mock.GetList(Arg.Any<CancellationToken>())
                .Returns(StatusDtoMock.CreateDictionaryInProgress());

            return mock;
        }
    }
}