using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira;
using NSubstitute;
using System;
using System.Threading;

namespace MeControla.AgileManager.Core.Tests.Mocks.Services
{
    public class IssuesResolvedInDateRangeServiceMock
    {
        public static IIssuesResolvedInDateRangeService Create()
        {
            var mock = Substitute.For<IIssuesResolvedInDateRangeService>();
            mock.GetData(Arg.Is<string>(x => x.Equals(DataMock.TEXT_SEARCH_PROJECT)),
                         Arg.Is<DateTime>(x => x.Equals(DataMock.DATETIME_START_CYCLE)),
                         Arg.Is<DateTime>(x => x.Equals(DataMock.DATETIME_END_CYCLE)),
                         Arg.Any<CancellationToken>())
                .Returns(SearchDtoMock.CreateIssueDoneList());

            return mock;
        }
    }
}