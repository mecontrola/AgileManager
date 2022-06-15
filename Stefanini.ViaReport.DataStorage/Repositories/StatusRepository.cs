using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public class StatusRepository : BaseAsyncRepository<Status>, IStatusRepository
    {
        public StatusRepository(IDbAppContext context)
            : base(context, context.Statuses)
        { }

        public async Task<bool> ExistsByKeyAsync(long key, CancellationToken cancellationToken)
            => await ExistsAsync(entity => entity.Key.Equals(key), cancellationToken);

        public async Task<Status> FindByKeyAsync(long key, CancellationToken cancellationToken)
            => await FindAsync(entity => entity.Key.Equals(key), cancellationToken);
    }
}