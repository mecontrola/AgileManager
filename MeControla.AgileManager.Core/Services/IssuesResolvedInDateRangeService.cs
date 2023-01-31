using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
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