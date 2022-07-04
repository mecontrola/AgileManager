using Stefanini.ViaReport.Core.Builders.Jira;
using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public class IssuesNotCancelledAndRemovedService : BaseIssuesQueryService, IIssuesNotCancelledAndRemovedService
    {
        public IssuesNotCancelledAndRemovedService(ISearchPost searchPost)
            : base(searchPost)
        { }

        public async Task<SearchDto> GetData(string username,
                                             string password,
                                             string project,
                                             CancellationToken cancellationToken)
            => await RunCriterias(username, password, CreateJql(project), cancellationToken);

        protected static JqlBuilder CreateJql(string project)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddNotInIssueTypesCriteria(IssueTypes.SubTask, IssueTypes.Epic)
                         .AddNotInDeletedStatusesCriteria();
    }
}