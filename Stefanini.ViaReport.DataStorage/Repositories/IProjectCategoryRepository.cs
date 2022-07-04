using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public interface IProjectCategoryRepository : IAsyncRepository<ProjectCategory>
    {
        Task<ProjectCategory> FindByKeyAsync(long key, CancellationToken cancellationToken);
    }
}