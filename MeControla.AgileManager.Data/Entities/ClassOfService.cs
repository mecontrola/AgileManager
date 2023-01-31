using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Entities
{
    public class ClassOfService : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public IList<IssueExtraData> IssueExtraDatas { get; set; }
        public PreferenceClassOfService Preference { get; set; }
    }
}