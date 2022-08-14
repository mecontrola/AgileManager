using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface ICustomfieldRepository : IAsyncRepository<Customfield>
    {
        Task<bool> ExistsByKeyAsync(string key, CancellationToken cancellationToken);
        Task<IList<Customfield>> RetrieveActiveListAsync(CancellationToken cancellationToken);
    }
}