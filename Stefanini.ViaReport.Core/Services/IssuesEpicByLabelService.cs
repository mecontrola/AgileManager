using Stefanini.ViaReport.Core.Builders.Jira;
using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Data.Dtos.Jira;
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

        protected static JqlBuilder CreateJql(string project, string[] labels)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.Epic)
                         .AddNotInDeletedStatusesCriteria()
                         .AddLabelsCriteria(labels);
    }
}