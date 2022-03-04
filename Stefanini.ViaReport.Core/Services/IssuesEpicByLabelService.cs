using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public class IssuesEpicByLabelService : BaseIssuesQueryService, IIssuesEpicByLabelService
    {
        public IssuesEpicByLabelService(ISearchPost searchPost)
            : base(searchPost)
        { }

        public async Task<SearchDto> GetData(string username,
                                             string password,
                                             string project,
                                             string[] labels,
                                             CancellationToken cancellationToken)
            => await RunCriterias(username, password, CreateJql(project, labels), cancellationToken);

        protected static string[] CreateJql(string project, string[] labels)
            => new string[]
            {
                GetProjectCriteria(project),
                GetInIssueTypesCriteria(IssueTypes.Epic),
                GetNotInDeletedStatusesCriteria(),
                In("labels", labels)
            };
    }
}