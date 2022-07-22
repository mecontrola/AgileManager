using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public interface IIssueEpicRepository : IAsyncRepository<IssueEpic>
    {
        Task<IssueEpic> FindByIssueIdAsync(long issueId, CancellationToken cancellationToken);
        Task<IList<IssueEpic>> RetrieveByQuarterAsync(long projectId, string quarter, CancellationToken cancellationToken);
    }
}