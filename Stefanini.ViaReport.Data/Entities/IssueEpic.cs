using MeControla.Core.Data.Entities;
using System;

namespace Stefanini.ViaReport.Data.Entities
{
    public class IssueEpic : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public decimal Progress { get; set; }
        public string Quarter { get; set; }
        public long IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}