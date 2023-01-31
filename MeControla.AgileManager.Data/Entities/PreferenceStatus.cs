using System;

namespace MeControla.AgileManager.Data.Entities
{
    public class PreferenceStatus
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public uint Order { get; set; }
        public decimal Progress { get; set; }
        public long StatusId { get; set; }
        public Status Status { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}