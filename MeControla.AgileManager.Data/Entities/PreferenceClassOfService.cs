using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Data.Entities;
using System;

namespace MeControla.AgileManager.Data.Entities
{
    public class PreferenceClassOfService : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public ClasseOfServices Type { get; set; }
        public long ClassOfServiceId { get; set; }
        public ClassOfService ClassOfService { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}