using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class StatusCategoryRepository : BaseAsyncRepository<StatusCategory>, IStatusCategoryRepository
    {
        public StatusCategoryRepository(IDbAppContext context)
            : base(context, context.StatusCategories)
        { }

        public async Task<StatusCategory> FindByKeyAsync(long key, CancellationToken cancellationToken)
            => await FindAsync(entity => entity.Key == key, cancellationToken);

        public async Task<bool> ExistsByKeyAsync(long key, CancellationToken cancellationToken)
            => await ExistsAsync(entity => entity.Key == key, cancellationToken);
    }
}