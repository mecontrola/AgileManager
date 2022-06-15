using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
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