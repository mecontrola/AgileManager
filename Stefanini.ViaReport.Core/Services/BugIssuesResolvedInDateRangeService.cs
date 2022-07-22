using Stefanini.ViaReport.Core.Builders.Jira;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Data.Enums;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class BugIssuesResolvedInDateRangeService : BaseIssuesInDateRangesService, IBugIssuesResolvedInDateRangeService
    {
        public BugIssuesResolvedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.Bug)
                         .AddBetweenResolvedDateCriteria(initDate, endDate)
                         .AddStatusCriteria(StatusTypes.Done);
    }
}