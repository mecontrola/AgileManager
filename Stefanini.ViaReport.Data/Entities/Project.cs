using Stefanini.Core.Data.Entities;
using System;

namespace Stefanini.ViaReport.Data.Entities
{
    public class Project : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
    }
}