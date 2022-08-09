using MeControla.AgileManager.Core.Builders.Jira;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Data.Enums;
using System;

namespace MeControla.AgileManager.Core.Services
{
    public class IssuesResolvedInDateRangeService : BaseIssuesInDateRangesService, IIssuesResolvedInDateRangeService
    {
        public IssuesResolvedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddNotInDeletedStatusesCriteria()
                         .AddBetweenResolvedDateCriteria(initDate, endDate)
                         .AddInIssueTypesCriteria(GetIssueTypes())
                         .AddKeyOrderBy();

        private static IssueTypes[] GetIssueTypes()
            => new[]
            {
                IssueTypes.Bug,
                IssueTypes.Task,
                IssueTypes.Improvement,
                IssueTypes.Story,
                IssueTypes.TechnicalDebt
            };
    }
}