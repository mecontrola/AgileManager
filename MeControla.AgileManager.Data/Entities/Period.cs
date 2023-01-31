using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Data.Entities;
using System;

namespace MeControla.AgileManager.Data.Entities
{
    public class Period : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Key { get; set; }
        public PeriodTypes Type { get; set; }
        public string Name { get; set; }
        public DateTime Initial { get; set; }
        public DateTime? Final { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}