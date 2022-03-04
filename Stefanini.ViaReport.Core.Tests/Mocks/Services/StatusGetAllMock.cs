using NSubstitute;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
{
    public class StatusGetAllMock
    {
        public static IStatusGetAll Create()
        {
            var statusGetAll = Substitute.For<IStatusGetAll>();
            statusGetAll.Execute(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                                 Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                                 Arg.Any<CancellationToken>())
                        .Returns(StatusDtoMock.CreateByJson());

            return statusGetAll;
        }
    }
}