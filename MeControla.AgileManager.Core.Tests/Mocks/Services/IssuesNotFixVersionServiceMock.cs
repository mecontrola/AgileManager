using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using NSubstitute;
using System.Threading;

namespace MeControla.AgileManager.Core.Tests.Mocks.Services
{
    public class IssuesNotFixVersionServiceMock
    {
        public static IIssuesNotFixVersionService Create()
        {
            var mock = Substitute.For<IIssuesNotFixVersionService>();
            mock.GetData(Arg.Is<string>(x => x.Equals(DataMock.TEXT_SEARCH_PROJECT)),
                         Arg.Any<CancellationToken>())
                .Returns(SearchDtoMock.CreateIssueDoneList());

            return mock;
        }
    }
}