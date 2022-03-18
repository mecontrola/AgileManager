using NSubstitute;
using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Core.Tests.Mocks.Dto;
using System.Threading;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Services
{
    public class IssuesNotFixVersionServiceMock
    {
        public static IIssuesNotFixVersionService Create()
        {
            var service = Substitute.For<IIssuesNotFixVersionService>();
            service.GetData(Arg.Is<string>(x => x.Equals(DataMock.VALUE_USERNAME)),
                            Arg.Is<string>(x => x.Equals(DataMock.VALUE_PASSWORD)),
                            Arg.Is<string>(x => x.Equals(DataMock.TEXT_SEARCH_PROJECT)),
                            Arg.Any<CancellationToken>())
                   .Returns(SearchDtoMock.CreateIssueDoneList());

            return service;
        }
    }
}