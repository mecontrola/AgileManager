using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Tests.TestUtils.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.AgileManager.Integrations.Jira.Tests.Mocks.Data.Dtos
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

        public static IssueDto CreateAllFilledStory()
            => new()
            {
                Id = DataMock.INT_ID_1.ToString(),
                Key = DataMock.ISSUE_KEY_1,
                Self = DataMock.ISSUE_SELF_1,
                Fields = IssueFieldsDtoMock.CreateAllFilledStory(),
                Changelog = ChangelogDtoMock.CreateList(),
            };

        public static IssueDto CreateAllFilledEpic()
            => new()
            {
                Id = DataMock.INT_ID_1.ToString(),
                Key = DataMock.ISSUE_KEY_2,
                Self = DataMock.ISSUE_SELF_2,
                Fields = IssueFieldsDtoMock.CreateAllFilledEpic(),
                Changelog = ChangelogDtoMock.CreateList(),
            };
    }
}