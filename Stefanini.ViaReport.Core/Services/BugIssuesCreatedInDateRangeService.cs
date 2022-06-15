using Stefanini.ViaReport.Core.Builders.Jira;
using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class BugIssuesCreatedInDateRangeService : BaseIssuesInDateRangesService, IBugIssuesCreatedInDateRangeService
    {
        public BugIssuesCreatedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.Bug)
                         .AddBetweenCreatedDateCriteria(initDate, endDate);
    }
}