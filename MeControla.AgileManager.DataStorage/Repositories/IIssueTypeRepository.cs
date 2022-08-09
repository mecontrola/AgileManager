using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IIssueTypeRepository : IAsyncRepository<IssueType>
    {
        Task<IssueType> FindByKeyAsync(long key, CancellationToken cancellationToken);
        Task<bool> ExistsByKeyAsync(long key, CancellationToken cancellationToken);
    }
}