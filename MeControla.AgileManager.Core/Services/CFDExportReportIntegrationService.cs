using MeControla.AgileManager.Core.Builders.Jira;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class CFDExportReportIntegrationService : BaseIssuesQueryService, ICFDExportReportIntegrationService
    {
        public CFDExportReportIntegrationService(ISearchPost searchPost)
            : base(searchPost)
        { }

        public async Task<SearchDto> GetData(string project, CancellationToken cancellationToken)
            => await RunCriterias(CreateJql(project), cancellationToken);

        protected static JqlBuilder CreateJql(string project)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddNotInDeletedStatusesCriteria()
                         .AddInIssueTypesCriteria(IssueTypes.Task, IssueTypes.Improvement, IssueTypes.Story);
    }
}