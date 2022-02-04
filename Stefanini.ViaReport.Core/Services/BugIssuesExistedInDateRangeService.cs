using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class BugIssuesExistedInDateRangeService : BaseIssuesInDateRangesService, IBugIssuesExistedInDateRangeService
    {
        public BugIssuesExistedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override string[] CreateJql(string project, DateTime initDate, DateTime endDate)
            => new string[]
            {
                GetProjectCriteria(project),
                GetIssueTypeCriteria(IssueTypes.Bug),
                GetIsLessThan(FIELD_CREATED, initDate),
                GetNotInDeletedStatusesCriteria(),
                Or(And(IsNull(FIELD_RESOLVED), GetNotInDeletedStatusesCriteria()), GetBetweenResolvedDateCriteria(initDate, endDate))
            };
    }
}