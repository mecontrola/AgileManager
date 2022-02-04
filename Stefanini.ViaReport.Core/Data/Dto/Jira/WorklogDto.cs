using System;

namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class WorklogDto
    {
        public UserDto Author { get; set; }
        public UserDto UpdateAuthor { get; set; }
        public DocumentFormat Comment { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public DateTime Started { get; set; }
        public string TimeSpent { get; set; }
        public long TimeSpentSeconds { get; set; }
        public string IssueId { get; set; }
    }
}