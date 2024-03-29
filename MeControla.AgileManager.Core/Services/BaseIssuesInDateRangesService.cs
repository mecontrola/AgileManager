﻿using MeControla.AgileManager.Core.Builders.Jira;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Data.Dtos.Jira;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public abstract class BaseIssuesInDateRangesService : BaseIssuesQueryService, IBaseIssuesInDateRangesService
    {
        public BaseIssuesInDateRangesService(ISearchPost searchPost)
            : base(searchPost)
        { }

        public async Task<SearchDto> GetData(string project,
                                             DateTime initDate,
                                             DateTime endDate,
                                             CancellationToken cancellationToken)
            => await RunCriterias(CreateJql(project, initDate, endDate), cancellationToken);

        protected abstract JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate);
    }
}