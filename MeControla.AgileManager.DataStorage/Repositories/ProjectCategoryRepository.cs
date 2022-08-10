using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class ProjectCategoryRepository : BaseAsyncRepository<ProjectCategory>, IProjectCategoryRepository
    {
        public ProjectCategoryRepository(IDbAppContext context)
            : base(context, context.ProjectCategories)
        { }

        public async Task<ProjectCategory> FindByKeyAsync(long key, CancellationToken cancellationToken)
            => await FindAsync(entity => entity.Key == key, cancellationToken);
    }
}