namespace Stefanini.ViaReport.Data.Dtos.Jira
{
    public class IssueDto : BaseDto
    {
        public string Expand { get; set; }
        public string Key { get; set; }
        public IssueFieldsDto Fields { get; set; }
        public ChangelogDto Changelog { get; set; }
    }
}