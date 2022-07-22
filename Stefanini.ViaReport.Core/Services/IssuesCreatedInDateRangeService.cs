using Stefanini.ViaReport.Core.Builders.Jira;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;

namespace Stefanini.ViaReport.Core.Services
{
    public class IssuesCreatedInDateRangeService : BaseIssuesInDateRangesService, IIssuesCreatedInDateRangeService
    {
        public IssuesCreatedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddNotInDeletedStatusesCriteria()
                         .AddBetweenCreatedDateCriteria(initDate, endDate)
                         .AddBasicIssueTypesCriteria();
    }
}