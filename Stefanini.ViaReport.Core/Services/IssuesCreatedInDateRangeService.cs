using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class IssuesCreatedInDateRangeService : BaseIssuesInDateRangesService, IIssuesCreatedInDateRangeService
    {
        public IssuesCreatedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override string[] CreateJql(string project, DateTime initDate, DateTime endDate)
            => new string[]
            {
                GetProjectCriteria(project),
                GetNotInDeletedStatusesCriteria(),
                GetBetweenCreatedDateCriteria(initDate, endDate),
                GetBasicIssueTypesCriteria()
            };
    }
}