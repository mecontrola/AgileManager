namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class IssuelinkDto
    {
        public IssuelinkTypeDto Type { get; set; }
        public IssueDto OutwardIssue { get; set; }
        public IssueDto InwardIssue { get; set; }
    }
}