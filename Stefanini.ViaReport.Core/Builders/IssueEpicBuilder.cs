﻿using MeControla.Core.Builders;
using Stefanini.ViaReport.Data.Entities;
using System;

namespace Stefanini.ViaReport.Core.Builders
{
    public class IssueEpicBuilder : BaseBuilder<IssueEpicBuilder, IssueEpic>, IBuilder<IssueEpic>
    {
        protected override void Initialize()
            => obj = new()
            {
                Uuid = Guid.NewGuid()
            };

        public IssueEpicBuilder SetProgress(decimal value)
            => Set(obj => obj.Progress = value);

        public IssueEpicBuilder SetQuarter(string value)
            => Set(obj => obj.Quarter = value);

        public IssueEpicBuilder SetIssueId(long value)
            => Set(obj => obj.IssueId = value);
    }
}