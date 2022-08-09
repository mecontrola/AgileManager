using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IQuarterRepository : IAsyncRepository<Quarter>
    {
        Task<Quarter> RetrieveByNameAsync(string name, CancellationToken cancellationToken);
        Task<IList<Quarter>> Get5LastListAsync(CancellationToken cancellationToken);
    }
}