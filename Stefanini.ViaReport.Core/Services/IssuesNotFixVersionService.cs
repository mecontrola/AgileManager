using Stefanini.ViaReport.Core.Builders.Jira;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public class IssuesNotFixVersionService : BaseIssuesQueryService, IIssuesNotFixVersionService
    {
        public IssuesNotFixVersionService(ISearchPost searchPost)
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
                         .AddFixVersionIsNull()
                         .AddNotInDeletedStatusesCriteria()
                         .AddNotInStatusCategoriesCriteria(StatusCategories.ToDo)
                         .AddNotInIssueTypesCriteria(IssueTypes.Epic, IssueTypes.SubTask);
    }
}