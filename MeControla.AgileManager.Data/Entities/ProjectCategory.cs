using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Entities
{
    public class ProjectCategory : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public long Key { get; set; }
        public string Name { get; set; }
        public IList<Project> Projects { get; set; }
    }
}