using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class IssueInfoDtoMock
    {
        public static IssueInfoDto CreateIssue1()
            => new()
            {
                Key = DataMock.ISSUE_KEY_1,
                Description = DataMock.ISSUE_DESCRIPTION_1,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Link = DataMock.ISSUE_LINK_1,
                Status = DataMock.ISSUE_STATUS_1,
            };

        public static IssueInfoDto CreateIssue2()
            => new()
            {
                Key = DataMock.ISSUE_KEY_2,
                Description = DataMock.ISSUE_DESCRIPTION_2,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Link = DataMock.ISSUE_LINK_2,
                Status = DataMock.ISSUE_STATUS_2,
            };

        public static IList<IssueInfoDto> CreateList()
            => new List<IssueInfoDto>
            {
                CreateIssue1(),
                CreateIssue2()
            };
    }
}
