namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class IssuelinkDto
    {
        public IssuelinkTypeDto Type { get; set; }
        public IssueDto OutwardIssue { get; set; }
        public IssueDto InwardIssue { get; set; }
    }
}