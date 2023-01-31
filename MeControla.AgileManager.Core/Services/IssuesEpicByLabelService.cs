using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class IssuesEpicByLabelService : BaseIssuesQueryService, IIssuesEpicByLabelService
    {
        public IssuesEpicByLabelService(ISearchPost searchPost)
            : base(searchPost)
        { }

        public async Task<SearchDto> GetData(string project,
                                             string[] labels,
                                             CancellationToken cancellationToken)
            => await RunCriterias(CreateJql(project, labels), cancellationToken);

        protected static JqlBuilder CreateJql(string project, string[] labels)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.Epic)
                         .AddNotInDeletedStatusesCriteria()
                         .AddLabelsCriteria(labels);
    }
}