using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
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

        protected static string[] CreateJql(string project)
            => new string[]
            {
                GetProjectCriteria(project),
                GetNotInIssueTypesCriteria(IssueTypes.SubTask, IssueTypes.Epic),
                GetNotInDeletedStatusesCriteria(),
            };
    }
}