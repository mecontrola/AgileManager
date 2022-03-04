using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class BugIssuesOpenedInDateRangeService : BaseIssuesInDateRangesService, IBugIssuesOpenedInDateRangeService
    {
        public BugIssuesOpenedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override string[] CreateJql(string project, DateTime initDate, DateTime endDate)
            => new string[]
            {
                GetProjectCriteria(project),
                GetInIssueTypesCriteria(IssueTypes.Bug),
                GetNotInStatusCategoriesCriteria(StatusCategories.Done)
            };
    }
}