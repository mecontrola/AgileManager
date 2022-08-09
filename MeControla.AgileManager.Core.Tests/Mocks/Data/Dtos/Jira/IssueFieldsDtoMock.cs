using MeControla.AgileManager.Data.Dtos.Jira;

namespace MeControla.AgileManager.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class IssueFieldsDtoMock
    {
        public static IssueFieldsDto CreateFieldsIssue1()
            => new()
            {
                Summary = DataMock.ISSUE_SUMMARY_1,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Status = StatusDtoMock.CreateBacklog()
            };

        public static IssueFieldsDto CreateFieldsIssue2()
            => new()
            {
                Summary = DataMock.ISSUE_SUMMARY_2,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Status = StatusDtoMock.CreateReplanishment(),
                Labels = DataMock.ISSUE_LABEL_2_INCIDENT
            };

        public static IssueFieldsDto CreateAllFilledStory()
            => new()
            {
                Summary = DataMock.ISSUE_SUMMARY_1,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Status = StatusDtoMock.CreateParaDesenvolvimento(),
                Issuetype = IssueTypeDtoMock.CreateStory(),
                Updated = DataMock.DATETIME_FIRST_DAY_YEAR
            };

        public static IssueFieldsDto CreateAllFilledEpic()
            => new()
            {
                Summary = DataMock.ISSUE_SUMMARY_1,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Status = StatusDtoMock.CreateParaDesenvolvimento(),
                Issuetype = IssueTypeDtoMock.CreateEpic(),
                Updated = DataMock.DATETIME_FIRST_DAY_YEAR
            };
    }
}