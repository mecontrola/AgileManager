using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class IssueStatusHistoryRepository : BaseAsyncRepository<IssueStatusHistory>, IIssueStatusHistoryRepository
    {
        public IssueStatusHistoryRepository(IDbAppContext context)
            : base(context, context.IssueStatusHistories)
        { }

        public async Task<bool> ExistsByIssueAndStatusAsync(long issueId, long statusId, CancellationToken cancellationToken)
            => await ExistsAsync(entity => entity.IssueId == issueId
                                        && entity.ToStatusId == statusId, cancellationToken);

        public async Task<DateTime?> FindDateTimeFirstHistoryByStatusCategoryAsync(long issueId, StatusCategories statusCategories, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Where(entity => entity.IssueId == issueId
                                        && entity.ToStatus.StatusCategory.Preference.Type == statusCategories)
                          .OrderBy(entity => entity.DateTime)
                          .Select(entity => (DateTime?)entity.DateTime)
                          .FirstOrDefaultAsync(cancellationToken);

        public async Task<IList<IssueStatusHistory>> FindIssuesByProjectAndRangeDateTimeAsync(long projectId, DateTime init, DateTime end, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Issue)
                          .Include(entity => entity.FromStatus)
                          .Where(entity => dbSet.Any(itm => itm.IssueId == entity.IssueId
                                                         && itm.DateTime.Date >= init.Date
                                                         && itm.DateTime.Date <= end.Date
                                                         && itm.Issue.ProjectId == projectId)
                                        && (context as IDbAppContext).PreferenceIssueTypes.Any(itm => itm.IssueTypeId == entity.Issue.IssueTypeId
                                                                                                   && itm.Type != IssueTypes.Story))
                          .ToListAsync(cancellationToken);

        public async Task<IList<IssueStatusHistory>> FindAllStatusCategoryInProgressAsync(long issueId, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.FromStatus)
                          .Include(entity => entity.ToStatus)
                          .Where(entity => (entity.ToStatus.StatusCategoryId == 3 // In Progress
                                        || entity.ToStatus.StatusCategoryId == 4) // Done
                                        && entity.IssueId == issueId)
                          .ToListAsync(cancellationToken);
    }
}