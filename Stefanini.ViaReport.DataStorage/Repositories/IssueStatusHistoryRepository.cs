using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public class IssueStatusHistoryRepository : BaseAsyncRepository<IssueStatusHistory>, IIssueStatusHistoryRepository
    {
        public IssueStatusHistoryRepository(IDbAppContext context)
            : base(context, context.IssueStatusHistories)
        { }

        public async Task<bool> ExistsByIssueAndStatusAsync(long issueId, long statusId, CancellationToken cancellationToken)
            => await ExistsAsync(entity => entity.IssueId == issueId
                                        && entity.StatusId == statusId, cancellationToken);
    }
}