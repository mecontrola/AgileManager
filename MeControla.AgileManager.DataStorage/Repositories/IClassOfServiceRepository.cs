using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IClassOfServiceRepository : IAsyncRepository<ClassOfService>
    {
        Task<bool> ExistsByKeyAsync(string key, CancellationToken cancellationToken);
        Task<IDictionary<string, long>> ToDictionaryAsync(CancellationToken cancellationToken);
    }
}