using MeControla.Core.Builders;
using MeControla.AgileManager.Data.Entities;
using System;

namespace MeControla.AgileManager.Core.Builders
{
    public class QuarterBuilder : BaseBuilder<QuarterBuilder, Quarter>, IBuilder<Quarter>
    {
        protected override void Initialize()
            => obj = new()
            {
                Uuid = Guid.NewGuid()
            };

        public QuarterBuilder SetName(string value)
            => Set(obj => obj.Name = value);
    }
}