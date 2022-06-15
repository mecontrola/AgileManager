using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public interface IIssueStatusHistoryRepository : IAsyncRepository<IssueStatusHistory>
    {
        Task<bool> ExistsByIssueAndStatusAsync(long issueId, long statusId, CancellationToken cancellationToken);
    }
}