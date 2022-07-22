using Stefanini.ViaReport.Core.Builders.Jira;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Data.Enums;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class TechnicalDebitIssuesResolvedInDateRangeService : BaseIssuesInDateRangesService, ITechnicalDebitIssuesResolvedInDateRangeService
    {
        public TechnicalDebitIssuesResolvedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.TechnicalDebt)
                         .AddBetweenResolvedDateCriteria(initDate, endDate)
                         .AddStatusCriteria(StatusTypes.Done);
    }
}