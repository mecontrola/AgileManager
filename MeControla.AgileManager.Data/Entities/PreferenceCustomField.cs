using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Data.Entities;
using System;

namespace MeControla.AgileManager.Data.Entities
{
    public class PreferenceCustomField : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public CustomFields Type { get; set; }
        public long CustomFieldId { get; set; }
        public CustomField CustomField { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}