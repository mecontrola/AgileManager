using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IIssueCustomfieldDataRepository : IAsyncRepository<IssueCustomfieldData>
    {
        Task<IssueCustomfieldData> RetrieveByCustomfieldAndIssueAsync(long customfieldId, long issueId, CancellationToken cancellationToken);
        Task<IList<IssueCustomfieldData>> FindAllByIssueIdAsync(long issueId, CancellationToken cancellationToken);
    }
}