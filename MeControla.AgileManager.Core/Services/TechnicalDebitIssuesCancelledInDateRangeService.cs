using MeControla.AgileManager.Core.Builders.Jira;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Data.Enums;
using System;

namespace MeControla.AgileManager.Core.Services
{
    public class TechnicalDebitIssuesCancelledInDateRangeService : BaseIssuesInDateRangesService, ITechnicalDebitIssuesCancelledInDateRangeService
    {
        public TechnicalDebitIssuesCancelledInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.TechnicalDebt)
                         .AddBetweenResolvedDateCriteria(initDate, endDate)
                         .AddInDeletedStatusesCriteria();
    }
}