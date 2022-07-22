using Stefanini.ViaReport.Core.Builders.Jira;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Data.Enums;
using System;

namespace Stefanini.ViaReport.Core.Services
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