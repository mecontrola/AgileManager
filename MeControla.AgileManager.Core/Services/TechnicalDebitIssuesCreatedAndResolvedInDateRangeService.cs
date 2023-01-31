using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using System;

namespace MeControla.AgileManager.Core.Services
{
    public class TechnicalDebitIssuesCreatedAndResolvedInDateRangeService : BaseIssuesInDateRangesService, ITechnicalDebitIssuesCreatedAndResolvedInDateRangeService
    {
        public TechnicalDebitIssuesCreatedAndResolvedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.TechnicalDebt)
                         .AddBetweenCreatedDateCriteria(initDate, endDate)
                         .AddBetweenResolvedDateCriteria(initDate, endDate)
                         .AddStatusCriteria(StatusTypes.Done);
    }
}