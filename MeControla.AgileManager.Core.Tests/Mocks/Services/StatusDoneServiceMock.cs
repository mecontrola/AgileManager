using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using NSubstitute;
using System.Threading;

namespace MeControla.AgileManager.Core.Tests.Mocks.Services
{
    public class StatusDoneServiceMock
    {
        public static IStatusDoneService Create()
        {
            var mock = Substitute.For<IStatusDoneService>();
            mock.GetList(Arg.Any<CancellationToken>())
                .Returns(StatusDtoMock.CreateDictionaryDone());

            return mock;
        }
    }
}