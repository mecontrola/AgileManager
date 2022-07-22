using NSubstitute;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
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