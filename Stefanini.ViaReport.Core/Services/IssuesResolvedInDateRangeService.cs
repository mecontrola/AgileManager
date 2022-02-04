using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class IssuesResolvedInDateRangeService : BaseIssuesInDateRangesService, IIssuesResolvedInDateRangeService
    {
        public IssuesResolvedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override string[] CreateJql(string project, DateTime initDate, DateTime endDate)
            => new string[]
            {
                GetProjectCriteria(project),
                GetNotInDeletedStatusesCriteria(),
                GetBetweenResolvedDateCriteria(initDate, endDate),
                GetIssueTypeCriteria(GetIssueTypes())
            };

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