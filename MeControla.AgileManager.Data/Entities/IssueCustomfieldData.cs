using MeControla.Core.Data.Entities;
using System;

namespace MeControla.AgileManager.Data.Entities
{
    public class IssueCustomfieldData : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Value { get; set; }
        public long CustomFieldId { get; set; }
        public CustomField CustomField { get; set; }
        public long IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}