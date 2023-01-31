using MeControla.Core.Data.Entities;
using System;

namespace MeControla.AgileManager.Data.Entities
{
    public class Deploy : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Services { get; set; }
        public DateTime? DeployedIn { get; set; }
        public long IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}