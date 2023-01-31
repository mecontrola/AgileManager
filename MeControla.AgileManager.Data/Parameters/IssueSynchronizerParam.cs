using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Parameters
{
    public class IssueSynchronizerParam
    {
        public IssueDto IssueDto { get; set; }
        public long ProjectId { get; set; }
        public IDictionary<string, long> Statuses { get; set; }
        public IDictionary<string, long> IssueTypes { get; set; }
    }
}