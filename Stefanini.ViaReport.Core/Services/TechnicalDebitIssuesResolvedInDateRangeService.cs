using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class TechnicalDebitIssuesResolvedInDateRangeService : BaseIssuesInDateRangesService, ITechnicalDebitIssuesResolvedInDateRangeService
    {
        public TechnicalDebitIssuesResolvedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override string[] CreateJql(string project, DateTime initDate, DateTime endDate)
            => new string[]
            {
                GetProjectCriteria(project),
                GetIssueTypeCriteria(IssueTypes.TechnicalDebt),
                GetBetweenResolvedDateCriteria(initDate, endDate),
                GetStatusCriteria(StatusTypes.Done)
            };
    }
}