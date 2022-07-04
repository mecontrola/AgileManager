using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Stefanini.ViaReport.Data.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public class IssueRepository : BaseAsyncRepository<Issue>, IIssueRepository
    {
        public IssueRepository(IDbAppContext context)
            : base(context, context.Issues)
        { }

        public async Task<DateTime?> GetLastUpdatedAsync(long projectId, CancellationToken cancellationToken)
        {
            var itens = await dbSet.AsNoTracking()
                                   .Where(entity => entity.ProjectId == projectId)
                                   .OrderByDescending(entity => entity.Updated)
                                   .Select(entity => entity.Updated)
                                   .ToListAsync(cancellationToken);
            return itens.Any()
                 ? itens.First()
                 : null;
        }

        public async Task<Issue> FindByKeyAsync(string key, CancellationToken cancellationToken)
            => await FindAsync(entity => entity.Key.Equals(key), cancellationToken);
    }
}