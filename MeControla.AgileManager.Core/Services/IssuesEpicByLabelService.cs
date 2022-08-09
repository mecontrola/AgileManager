using MeControla.AgileManager.Core.Builders.Jira;
using MeControla.AgileManager.Core.Integrations.Jira.V2.Projects;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Enums;
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