using Stefanini.ViaReport.Data.Dtos.Jira;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Data.Dtos.Jira
{
    public class IssueFieldsDtoMock
    {
        public static IssueFieldsDto CreateFieldsIssue1()
            => new()
            {
                Summary = DataMock.ISSUE_DESCRIPTION_1,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Status = StatusDtoMock.CreateBacklog()
            };

        public static IssueFieldsDto CreateFieldsIssue2()
            => new()
            {
                Summary = DataMock.ISSUE_DESCRIPTION_2,
                Created = DataMock.DATETIME_QUARTER_2_2000,
                Status = StatusDtoMock.CreateReplanishment(),
                Labels = DataMock.ISSUE_LABEL_2_INCIDENT
            };
    }
}