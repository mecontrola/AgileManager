using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using System;

namespace MeControla.AgileManager.Core.Services
{
    public class IssuesCreatedInDateRangeService : BaseIssuesInDateRangesService, IIssuesCreatedInDateRangeService
    {
        public IssuesCreatedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddNotInDeletedStatusesCriteria()
                         .AddBetweenCreatedDateCriteria(initDate, endDate)
                         .AddBasicIssueTypesCriteria();
    }
}