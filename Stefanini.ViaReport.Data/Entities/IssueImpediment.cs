using MeControla.Core.Data.Entities;
using System;

namespace Stefanini.ViaReport.Data.Entities
{
    public class IssueImpediment : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public long IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}