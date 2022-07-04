using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
        Task<bool> ExistsByKeyAsync(long key, CancellationToken cancellationToken);
        Task<IList<Project>> FindAllInIdListAsync(long[] ids, CancellationToken cancellationToken);
        Task<IList<Project>> FindAllWithCategoryAsync(CancellationToken cancellationToken);
        Task<IList<Project>> FindSelectedWithCategoryAsync(CancellationToken cancellationToken);
        Task<IList<long>> RetrieveSelectedIdsAsync(CancellationToken cancellationToken);
        Task<bool> UpdateAllToNoSelectedAsync(CancellationToken cancellationToken);
        Task<bool> UpdateToSelectedByIdsAsync(long[] ids, CancellationToken cancellationToken);
    }
}