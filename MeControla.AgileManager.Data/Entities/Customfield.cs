using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Entities
{
    public class Customfield : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Custom { get; set; }
        public bool Active { get; set; }
        public IList<IssueCustomfieldData> CustomfieldsData { get; set; }
    }
}