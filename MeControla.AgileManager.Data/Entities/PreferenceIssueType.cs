using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Data.Entities;
using System;

namespace MeControla.AgileManager.Data.Entities
{
    public class PreferenceIssueType : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public IssueTypes Type { get; set; }
        public long? IssueTypeId { get; set; }
        public IssueType IssueType { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}