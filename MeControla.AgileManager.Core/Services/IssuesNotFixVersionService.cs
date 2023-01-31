using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class IssuesNotFixVersionService : BaseIssuesQueryService, IIssuesNotFixVersionService
    {
        public IssuesNotFixVersionService(ISearchPost searchPost)
            : base(searchPost)
        { }

        public async Task<SearchDto> GetData(string project, CancellationToken cancellationToken)
            => await RunCriterias(CreateJql(project), cancellationToken);

        protected static JqlBuilder CreateJql(string project)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddFixVersionIsNull()
                         .AddNotInDeletedStatusesCriteria()
                         .AddNotInStatusCategoriesCriteria(StatusCategories.ToDo)
                         .AddNotInIssueTypesCriteria(IssueTypes.Epic, IssueTypes.SubTask);
    }
}