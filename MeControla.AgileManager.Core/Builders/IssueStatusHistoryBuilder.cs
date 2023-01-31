using MeControla.Core.Builders;
using MeControla.AgileManager.Data.Entities;
using System;

namespace MeControla.AgileManager.Core.Builders
{
    public class IssueStatusHistoryBuilder : BaseBuilder<IssueStatusHistoryBuilder, IssueStatusHistory>, IBuilder<IssueStatusHistory>
    {
        protected override void Initialize()
            => obj = new()
            {
                Uuid = Guid.NewGuid()
            };

        public IssueStatusHistoryBuilder SetDateTime(DateTime value)
            => Set(obj => obj.DateTime = value);

        public IssueStatusHistoryBuilder SetFromStatusId(long value)
            => Set(obj => obj.FromStatusId = value);

        public IssueStatusHistoryBuilder SetToStatusId(long value)
            => Set(obj => obj.ToStatusId = value);

        public IssueStatusHistoryBuilder SetIssueId(long value)
            => Set(obj => obj.IssueId = value);
    }
}