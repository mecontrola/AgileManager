using MeControla.Core.Data.Entities;
using System;

namespace MeControla.AgileManager.Data.Entities
{
    public class IssueStatusHistory : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime DateTime { get; set; }
        public long IssueId { get; set; }
        public Issue Issue { get; set; }
        public long FromStatusId { get; set; }
        public Status FromStatus { get; set; }
        public long ToStatusId { get; set; }
        public Status ToStatus { get; set; }
    }
}