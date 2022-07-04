using NSubstitute;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
{
    public class StatusDoneServiceMock
    {
        public static IStatusDoneService Create()
        {
            var mock = Substitute.For<IStatusDoneService>();
            mock.GetList(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                         Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                         Arg.Any<CancellationToken>())
                .Returns(StatusDtoMock.CreateDictionaryDone());

            return mock;
        }
    }
}