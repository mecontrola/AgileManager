using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class TechnicalDebitIssuesExistedInDateRangeService : BaseIssuesInDateRangesService, ITechnicalDebitIssuesExistedInDateRangeService
    {
        public TechnicalDebitIssuesExistedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override string[] CreateJql(string project, DateTime initDate, DateTime endDate)
            => new string[]
            {
                GetProjectCriteria(project),
                GetInIssueTypesCriteria(IssueTypes.TechnicalDebt),
                GetIsLessThan(FIELD_CREATED, initDate),
                Or(And(IsNull(FIELD_RESOLVED), GetNotInDeletedStatusesCriteria()), GetBetweenResolvedDateCriteria(initDate, endDate))
            };
    }
}