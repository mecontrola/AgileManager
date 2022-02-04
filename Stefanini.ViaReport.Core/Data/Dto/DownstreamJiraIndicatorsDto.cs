namespace Stefanini.ViaReport.Core.Data.Dto
{
    public class DownstreamJiraIndicatorsDto
    {
        public decimal CycleBalance { get; set; }
        public IssueInfoListDto BugsCreated { get; set; }
        public IssueInfoListDto BugsOpened { get; set; }
        public IssueInfoListDto BugsCreatedAndResolved { get; set; }
        public IssueInfoListDto BugsExisted { get; set; }
        public IssueInfoListDto BugsResolved { get; set; }
        public IssueInfoListDto BugsCancelled { get; set; }
        public IssueInfoListDto TechnicalDebitCreated { get; set; }
        public IssueInfoListDto TechnicalDebitCreatedAndResolved { get; set; }
        public IssueInfoListDto TechnicalDebitOpened { get; set; }
        public IssueInfoListDto TechnicalDebitExisted { get; set; }
        public IssueInfoListDto TechnicalDebitResolved { get; set; }
        public IssueInfoListDto TechnicalDebitCancelled { get; set; }
    }
}