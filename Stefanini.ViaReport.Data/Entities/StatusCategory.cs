using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Data.Entities
{
    public class StatusCategory : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public long Key { get; set; }
        public string Name { get; set; }
        public IList<Status> Statuses { get; set; }
    }
}