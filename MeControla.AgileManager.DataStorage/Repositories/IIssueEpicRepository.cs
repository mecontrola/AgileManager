using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IIssueEpicRepository : IAsyncRepository<IssueEpic>
    {
        Task<IssueEpic> FindByIssueIdAsync(long issueId, CancellationToken cancellationToken);
        Task<IList<IssueEpic>> RetrieveByQuarterAsync(long projectId, long quarterId, CancellationToken cancellationToken);
    }
}