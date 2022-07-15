using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public class IssueEpicRepository : BaseAsyncRepository<IssueEpic>, IIssueEpicRepository
    {
        private const long STATUS_KEY_CANCELLED = 10717;
        private const long STATUS_KEY_REMOVED = 11709;

        public IssueEpicRepository(IDbAppContext context)
            : base(context, context.IssueEpics)
        { }

        public async Task<IssueEpic> FindByIssueIdAsync(long issueId, CancellationToken cancellationToken)
            => await FindAsync(entity => entity.IssueId == issueId, cancellationToken);

        public async Task<IList<IssueEpic>> RetrieveByQuarterAsync(long projectId, string quarter, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Issue)
                          .Where(entity => entity.Issue.ProjectId == projectId
                                        && entity.Quarter.Contains(quarter)
                                        && context.Set<Status>()
                                                  .Where(status => status.Key != STATUS_KEY_CANCELLED
                                                                && status.Key != STATUS_KEY_REMOVED)
                                                  .Any(status => status.Id == entity.Issue.StatusId))
                          .OrderBy(entity => entity.Issue.Key)
                          .ToListAsync(cancellationToken);
    }
}