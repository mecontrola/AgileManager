using NSubstitute;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
{
    public class StatusInProgressServiceMock
    {
        public static IStatusInProgressService Create()
        {
            var mock = Substitute.For<IStatusInProgressService>();
            mock.GetList(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                         Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                         Arg.Any<CancellationToken>())
                .Returns(StatusDtoMock.CreateDictionaryInProgress());

            return mock;
        }
    }
}