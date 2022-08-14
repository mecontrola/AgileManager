using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Builders;
using System;

namespace MeControla.AgileManager.Core.Builders
{
    public class IssueCustomfieldDataBuilder : BaseBuilder<IssueCustomfieldDataBuilder, IssueCustomfieldData>, IBuilder<IssueCustomfieldData>
    {
        protected override void Initialize()
            => obj = new()
            {
                Uuid = Guid.NewGuid()
            };

        public IssueCustomfieldDataBuilder SetValue(string value)
            => Set(obj => obj.Value = value);

        public IssueCustomfieldDataBuilder SetCustomfieldId(long value)
            => Set(obj => obj.CustomfieldId = value);

        public IssueCustomfieldDataBuilder SetIssueId(long value)
            => Set(obj => obj.IssueId = value);
    }
}