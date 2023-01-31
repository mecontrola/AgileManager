using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using System;

namespace MeControla.AgileManager.Core.Services
{
    public class TechnicalDebitIssuesOpenedInDateRangeService : BaseIssuesInDateRangesService, ITechnicalDebitIssuesOpenedInDateRangeService
    {
        public TechnicalDebitIssuesOpenedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.TechnicalDebt)
                         .AddNotInStatusCategoriesCriteria(StatusCategories.Done);
    }
}