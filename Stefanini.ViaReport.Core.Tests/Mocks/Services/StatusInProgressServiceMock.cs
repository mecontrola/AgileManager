using NSubstitute;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
{
    public class StatusInProgressServiceMock
    {
        public static IStatusInProgressService Create()
        {
            var service = Substitute.For<IStatusInProgressService>();
            service.GetList(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                            Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                            Arg.Any<CancellationToken>())
                   .Returns(StatusDtoMock.CreateDictionaryInProgress());

            return service;
        }
    }
}