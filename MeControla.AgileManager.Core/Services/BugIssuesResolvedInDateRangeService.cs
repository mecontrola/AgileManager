using MeControla.AgileManager.Core.Builders.Jira;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Data.Enums;
using System;

namespace MeControla.AgileManager.Core.Services
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