using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public interface IStatusRepository : IAsyncRepository<Status>
    {
        Task<bool> ExistsByKeyAsync(long key, CancellationToken cancellationToken);
    }
}