using NSubstitute;
using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos;
using System.Threading;

namespace MeControla.AgileManager.Core.Tests.Mocks.Services
{
    public class QuarterServiceMock
    {
        public static IQuarterService Create()
        {
            var mock = Substitute.For<IQuarterService>();
            mock.LoadAllAsync(Arg.Any<CancellationToken>())
                .Returns(QuarterDtoMock.CreateList());

            return mock;
        }
    }
}