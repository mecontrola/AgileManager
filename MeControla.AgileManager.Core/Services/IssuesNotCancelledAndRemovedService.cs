using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
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