using MeControla.Core.Builders;
using Stefanini.ViaReport.Data.Entities;
using System;

namespace Stefanini.ViaReport.Core.Builders
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