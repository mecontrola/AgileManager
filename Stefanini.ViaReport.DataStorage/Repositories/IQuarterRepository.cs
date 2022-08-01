using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public interface IQuarterRepository : IAsyncRepository<Quarter>
    {
        Task<Quarter> RetrieveByNameAsync(string name, CancellationToken cancellationToken);
        Task<IList<Quarter>> Get5LastListAsync(CancellationToken cancellationToken);
    }
}