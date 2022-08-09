using MeControla.Core.Builders;
using MeControla.AgileManager.Data.Entities;
using System;

namespace MeControla.AgileManager.Core.Builders
{
    public class IssueImpedimentBuilder : BaseBuilder<IssueImpedimentBuilder, IssueImpediment>, IBuilder<IssueImpediment>
    {
        protected override void Initialize()
            => obj = new()
            {
                Uuid = Guid.NewGuid()
            };

        public IssueImpedimentBuilder SetStart(DateTime value)
            => Set(obj => obj.Start = value);

        public IssueImpedimentBuilder SetEnd(DateTime? value)
            => Set(obj => obj.End = value);

        public IssueImpedimentBuilder SetIssueId(long value)
            => Set(obj => obj.IssueId = value);
    }
}