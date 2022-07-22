using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Entities
{
    public class IssueMock
    {
        public static Issue CreateIssue1()
            => new()
            {
                Key = DataMock.ISSUE_KEY_1,
                Summary = DataMock.ISSUE_SUMMARY_1,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Link = DataMock.ISSUE_LINK_1,
            };

        public static Issue CreateIssue2()
            => new()
            {
                Key = DataMock.ISSUE_KEY_2,
                Summary = DataMock.ISSUE_SUMMARY_2,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Link = DataMock.ISSUE_LINK_2,
                Incident = true
            };

        public static IList<Issue> CreateList()
            => new List<Issue>
            {
                CreateIssue1(),
                CreateIssue2()
            };

        public static Issue CreateAllFilledStory()
            => new()
            {
                Id = DataMock.INT_ID_1,
                Key = DataMock.ISSUE_KEY_1,
                Summary = DataMock.ISSUE_SUMMARY_1,
                Created = DataMock.DATETIME_FIRST_DAY_YEAR,
                Updated = DataMock.DATETIME_FIRST_DAY_YEAR,
                IssueTypeId = DataMock.INT_ID_6,
                IssueType = IssueTypeMock.CreateStory(),
                StatusId = DataMock.INT_ID_5,
                Status = StatusMock.CreateParaDesenvolvimento(),
                ProjectId = DataMock.INT_ID_1,
                Project = ProjectMock.CreateSearch(),
            };

        public static Issue CreateAllFilledEpic()
            => new()
            {
                Id = DataMock.INT_ID_3,
                Key = DataMock.ISSUE_KEY_3,
                Summary = DataMock.ISSUE_SUMMARY_3,
                Created = DataMock.DATETIME_FIRST_DAY_YEAR,
                Updated = DataMock.DATETIME_FIRST_DAY_YEAR,
                IssueTypeId = DataMock.INT_ID_6,
                IssueType = IssueTypeMock.CreateEpic(),
                StatusId = DataMock.INT_ID_6,
                Status = StatusMock.CreateEmDesenvolvimento(),
                ProjectId = DataMock.INT_ID_1,
                Project = ProjectMock.CreateSearch(),
            };

        public static IList<Issue> CreateListAllFilled()
            => new List<Issue>
            {
                CreateAllFilledStory(),
                CreateAllFilledEpic()
            };
    }
}