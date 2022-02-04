using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class IssueDtoMock
    {
        public static IssueDto CreateIssue1()
            => new()
            {
                Key = DataMock.ISSUE_KEY_1,
                Self = DataMock.ISSUE_SELF_1,
                Fields = IssueFieldsDtoMock.CreateFieldsIssue1()
            };

        public static IssueDto CreateIssue2()
            => new()
            {
                Key = DataMock.ISSUE_KEY_2,
                Self = DataMock.ISSUE_SELF_2,
                Fields = IssueFieldsDtoMock.CreateFieldsIssue2()
            };

        public static IList<IssueDto> CreateList()
            => new List<IssueDto>
            {
                CreateIssue1(),
                CreateIssue2()
            };
    }
}