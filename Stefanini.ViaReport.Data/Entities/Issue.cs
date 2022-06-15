using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Data.Entities
{
    public class Issue : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Key { get; set; }
        public string Summary { get; set; }
        public bool Incident { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Resolved { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
        public long StatusId { get; set; }
        public Status Status { get; set; }
        public long IssueTypeId { get; set; }
        public IssueType IssueType { get; set; }
        public IList<IssueStatusHistory> Statuses { get; set; }
    }
}