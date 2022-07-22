using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Data.Entities
{
    public class Status : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public long Key { get; set; }
        public string Name { get; set; }
        public long StatusCategoryId { get; set; }
        public StatusCategory StatusCategory { get; set; }
        public IList<Issue> Issues { get; set; }
    }
}