using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Data.Parameters
{
    public class IssueSynchronizerParam
    {
        public IssueDto IssueDto { get; set; }
        public long ProjectId { get; set; }
        public IDictionary<string, long> Statuses { get; set; }
        public IDictionary<string, long> IssueTypes { get; set; }
    }
}