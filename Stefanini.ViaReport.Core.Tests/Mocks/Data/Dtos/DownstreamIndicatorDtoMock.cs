using Stefanini.ViaReport.Data.Dtos;
using Stefanini.ViaReport.Data.Enums;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos
{
    public class DownstreamIndicatorDtoMock
    {
        public static DownstreamIndicatorDto Create()
            => new()
            {
                CycleBalance = 0,
                Bugs = CreateListBugs(),
                TechnicalDebit = CreateListTechnicalDebit(),
            };

        private static IDictionary<DownstreamIndicatorTypes, IList<IssueDto>> CreateListBugs()
            => new Dictionary<DownstreamIndicatorTypes, IList<IssueDto>>
            {
                { DownstreamIndicatorTypes.Created, new List<IssueDto> { IssueDtoMock.CreateAllFilledBug() } },
                { DownstreamIndicatorTypes.Opened, new List<IssueDto>()  },
                { DownstreamIndicatorTypes.Existed, new List<IssueDto>() },
                { DownstreamIndicatorTypes.Resolved, new List<IssueDto>() },
                { DownstreamIndicatorTypes.CreatedAndResolved, new List<IssueDto>() },
                { DownstreamIndicatorTypes.Cancelled, new List<IssueDto>() },
            };

        private static IDictionary<DownstreamIndicatorTypes, IList<IssueDto>> CreateListTechnicalDebit()
            => new Dictionary<DownstreamIndicatorTypes, IList<IssueDto>>
            {
                { DownstreamIndicatorTypes.Created, new List<IssueDto>() },
                { DownstreamIndicatorTypes.Opened, new List<IssueDto>() },
                { DownstreamIndicatorTypes.Existed, new List<IssueDto>() },
                { DownstreamIndicatorTypes.Resolved, new List<IssueDto>() },
                { DownstreamIndicatorTypes.CreatedAndResolved, new List<IssueDto>() },
                { DownstreamIndicatorTypes.Cancelled, new List<IssueDto>() },
            };
    }
}