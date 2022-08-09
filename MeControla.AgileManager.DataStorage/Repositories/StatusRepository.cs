using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class StatusRepository : BaseAsyncRepository<Status>, IStatusRepository
    {
        public StatusRepository(IDbAppContext context)
            : base(context, context.Statuses)
        { }

        public async Task<bool> ExistsByKeyAsync(long key, CancellationToken cancellationToken)
            => await ExistsAsync(entity => entity.Key.Equals(key), cancellationToken);
    }
}