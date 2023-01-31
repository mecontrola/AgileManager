using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Entities
{
    public class Issue : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Key { get; set; }
        public string Summary { get; set; }
        public bool Incident { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime? Resolved { get; set; }
        public string Labels { get; set; }
        public string Link { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
        public long StatusId { get; set; }
        public Status Status { get; set; }
        public long IssueTypeId { get; set; }
        public IssueType IssueType { get; set; }
        public IssueEpic IssueEpic { get; set; }
        public IssueExtraData ExtraData { get; set; }
        public long? DeployId { get; set; }
        public Deploy Deploy { get; set; }
        public IList<IssueImpediment> Impediments { get; set; }
        public IList<IssueStatusHistory> Statuses { get; set; }
        public IList<IssueCustomfieldData> CustomfieldsData { get; set; }
    }
}