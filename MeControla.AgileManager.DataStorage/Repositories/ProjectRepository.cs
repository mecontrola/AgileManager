using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class ProjectRepository : BaseAsyncRepository<Project>, IProjectRepository
    {
        public ProjectRepository(IDbAppContext context)
            : base(context, context.Projects)
        { }

        public async Task<bool> ExistsByKeyAsync(long key, CancellationToken cancellationToken)
            => await ExistsAsync(entity => entity.Key.Equals(key), cancellationToken);

        public async Task<IList<Project>> FindAllInIdListAsync(long[] ids, CancellationToken cancellationToken)
            => await dbSet.Where(entity => ids.Any(x => x == entity.Id))
                          .ToListAsync(cancellationToken);

        public async Task<IList<Project>> FindAllWithCategoryAsync(CancellationToken cancellationToken)
            => await dbSet.Include(entity => entity.ProjectCategory)
                          .ToListAsync(cancellationToken);

        public async Task<IList<Project>> FindSelectedWithCategoryAsync(CancellationToken cancellationToken)
            => await dbSet.Include(entity => entity.ProjectCategory)
                          .Where(entity => entity.Selected)
                          .ToListAsync(cancellationToken);

        public async Task<IList<long>> RetrieveSelectedIdsAsync(CancellationToken cancellationToken)
            => await dbSet.Where(entity => entity.Selected)
                          .Select(entity => entity.Id)
                          .ToListAsync(cancellationToken);

        public async Task<bool> UpdateAllToNoSelectedAsync(CancellationToken cancellationToken)
        {
            var entities = await dbSet.ToListAsync(cancellationToken);
            entities.ForEach(entity => entity.Selected = false);
            dbSet.UpdateRange(entities);
            return await context.SaveChangesAsync(cancellationToken) != 0;
        }

        public async Task<bool> UpdateToSelectedByIdsAsync(long[] ids, CancellationToken cancellationToken)
        {
            var entities = await dbSet.Where(entity => ids.Any(id => id == entity.Id)).ToListAsync(cancellationToken);
            entities.ForEach(entity => entity.Selected = true);
            dbSet.UpdateRange(entities);
            return await context.SaveChangesAsync(cancellationToken) != 0;
        }
    }
}