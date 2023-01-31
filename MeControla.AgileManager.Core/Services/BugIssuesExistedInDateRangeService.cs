using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using System;

namespace MeControla.AgileManager.Core.Services
{
    public class BugIssuesExistedInDateRangeService : BaseIssuesInDateRangesService, IBugIssuesExistedInDateRangeService
    {
        public BugIssuesExistedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.Bug)
                         .AddCreatedIsLessThan(initDate)
                         .AddNotInDeletedStatusesCriteria()
                         .AddOr(x => x.AddAnd(y => y.AddResolvedIsNull()
                                                    .AddNotInDeletedStatusesCriteria())
                                      .AddBetweenResolvedDateCriteria(initDate, endDate));
    }
}