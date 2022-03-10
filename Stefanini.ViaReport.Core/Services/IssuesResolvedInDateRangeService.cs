using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class IssuesResolvedInDateRangeService : BaseIssuesInDateRangesService, IIssuesResolvedInDateRangeService
    {
        private const string CUSTOM_FIELD_END_DATE = "cf[14503]";

        public IssuesResolvedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override string[] CreateJql(string project, DateTime initDate, DateTime endDate)
            => new string[]
            {
                GetProjectCriteria(project),
                GetNotInDeletedStatusesCriteria(),
                Or(GetBetweenResolvedDateCriteria(initDate, endDate),
                   GetBetweenDatesCriteria(CUSTOM_FIELD_END_DATE, initDate, endDate)),
                GetInIssueTypesCriteria(GetIssueTypes())
            };

        protected override string CreateOrderBy()
            => OrderByKey();

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