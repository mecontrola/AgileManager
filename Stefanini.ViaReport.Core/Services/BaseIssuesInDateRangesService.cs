using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public abstract class BaseIssuesInDateRangesService : BaseIssuesQueryService, IBaseIssuesInDateRangesService
    {
        public BaseIssuesInDateRangesService(ISearchPost searchPost)
            : base(searchPost)
        { }

        public async Task<SearchDto> GetData(string username,
                                             string password,
                                             string project,
                                             DateTime initDate,
                                             DateTime endDate,
                                             CancellationToken cancellationToken)
            => await RunCriterias(username, password, CreateJql(project, initDate, endDate), CreateOrderBy(), cancellationToken);

        protected abstract string[] CreateJql(string project, DateTime initDate, DateTime endDate);

        protected virtual string CreateOrderBy()
            => string.Empty;
    }
}