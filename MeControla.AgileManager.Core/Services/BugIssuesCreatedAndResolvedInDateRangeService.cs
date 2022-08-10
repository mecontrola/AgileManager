using MeControla.AgileManager.Core.Builders.Jira;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Data.Enums;
using System;

namespace MeControla.AgileManager.Core.Services
{
    public class BugIssuesCreatedAndResolvedInDateRangeService : BaseIssuesInDateRangesService, IBugIssuesCreatedAndResolvedInDateRangeService
    {
        public BugIssuesCreatedAndResolvedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.Bug)
                         .AddBetweenCreatedDateCriteria(initDate, endDate)
                         .AddBetweenResolvedDateCriteria(initDate, endDate)
                         .AddStatusCriteria(StatusTypes.Done)
                         .AddNotInDeletedStatusesCriteria();
    }
}