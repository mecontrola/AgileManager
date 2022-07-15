using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Stefanini.ViaReport.Data.Entities;
using Stefanini.ViaReport.Data.Enums;
using System;
using System.Linq;
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

        public async Task<DateTime?> FindDateTimeFirstHistoryByStatusCategoryAsync(long issueId, StatusCategories statusCategories, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Where(entity => entity.IssueId == issueId
                                        && entity.Status.StatusCategory.Key == (long)statusCategories)
                          .OrderBy(entity => entity.DateTime)
                          .Select(entity => entity.DateTime)
                          .FirstAsync(cancellationToken);
    }
}