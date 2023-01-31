using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Data.Entities;
using System;

namespace MeControla.AgileManager.Data.Entities
{
    public class PreferenceStatusCategory : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public StatusCategories Type { get; set; }
        public long StatusCategoryId { get; set; }
        public StatusCategory StatusCategory { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}