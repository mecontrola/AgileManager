using Stefanini.ViaReport.Core.Data.Dto.Jira;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Dto
{
    public class IssueFieldsDtoMock
    {
        public static IssueFieldsDto CreateFieldsIssue1()
            => new()
            {
                Summary = DataMock.ISSUE_DESCRIPTION_1,
                Created = DataMock.DATETIME_DEFAULT,
                Status = StatusDtoMock.CreateBacklog()
            };

        public static IssueFieldsDto CreateFieldsIssue2()
            => new()
            {
                Summary = DataMock.ISSUE_DESCRIPTION_2,
                Created = DataMock.DATETIME_DEFAULT,
                Status = StatusDtoMock.CreateReplanishment()
            };
    }
}