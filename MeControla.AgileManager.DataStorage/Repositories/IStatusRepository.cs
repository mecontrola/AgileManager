using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IStatusRepository : IAsyncRepository<Status>
    {
        Task<bool> ExistsByKeyAsync(long key, CancellationToken cancellationToken);
    }
}