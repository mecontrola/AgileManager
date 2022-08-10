using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IProjectCategoryRepository : IAsyncRepository<ProjectCategory>
    {
        Task<ProjectCategory> FindByKeyAsync(long key, CancellationToken cancellationToken);
    }
}