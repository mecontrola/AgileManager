using MeControla.AgileManager.Core.Builders.Jira;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class IssuesNotCancelledAndRemovedService : BaseIssuesQueryService, IIssuesNotCancelledAndRemovedService
    {
        public IssuesNotCancelledAndRemovedService(ISearchPost searchPost)
            : base(searchPost)
        { }

        public async Task<SearchDto> GetData(string project, CancellationToken cancellationToken)
            => await RunCriterias(CreateJql(project), cancellationToken);

        protected static JqlBuilder CreateJql(string project)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddNotInIssueTypesCriteria(IssueTypes.SubTask, IssueTypes.Epic)
                         .AddNotInDeletedStatusesCriteria();
    }
}