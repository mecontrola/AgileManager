using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IStatusCategoryRepository : IAsyncRepository<StatusCategory>
    {
        Task<StatusCategory> FindByKeyAsync(long key, CancellationToken cancellationToken);
        Task<bool> ExistsByKeyAsync(long key, CancellationToken cancellationToken);
    }
}