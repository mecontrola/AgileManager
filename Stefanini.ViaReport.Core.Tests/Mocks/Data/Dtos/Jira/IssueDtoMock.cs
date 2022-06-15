using Stefanini.ViaReport.Core.Tests.TestUtils.Helpers;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
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

        public static IList<IssueDto> CreatePart1To5From10()
            => CreateIssueByJson("SEA-273", "SEA-267", "SEA-266", "SEA-264", "SEA-262");

        public static IList<IssueDto> CreatePart6To10From10()
            => CreateIssueByJson("SEA-259", "SEA-257", "SEA-255", "SEA-254", "SEA-248");

        public static IssueDto CreateIssueByJson(string key)
            => ApiUtilMockHelper.LoadIssueJsonMock(key);

        private static IList<IssueDto> CreateIssueByJson(params string[] key)
            => key.Select(x => ApiUtilMockHelper.LoadIssueJsonMock(x))
                  .ToList();
    }
}