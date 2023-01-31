using MeControla.Core.Data.Entities;
using System;

namespace MeControla.AgileManager.Data.Entities
{
    public class IssueExtraData : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public Issue Issue { get; set; }
        public decimal StoryPoints { get; set; }
        public bool Impediment { get; set; }
        public long? ClassOfServiceId { get; set; }
        public ClassOfService ClassOfService { get; set; }
        public decimal CustomerLeadTime { get; set; }
        public decimal DiscoveryLeadTime { get; set; }
        public decimal SystemLeadTime { get; set; }
    }
}