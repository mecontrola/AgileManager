using MeControla.AgileManager.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public interface IProjectBusiness
    {
        Task<IList<ProjectDto>> ListAllWithCategoryAsync(CancellationToken cancellationToken);
        Task<IList<ProjectDto>> ListSelectedWithCategoryAsync(CancellationToken cancellationToken);
        Task<IList<long>> ListSelectedIdsAsync(CancellationToken cancellationToken);
        Task<bool> SetSelectedByIdAsync(long[] id, CancellationToken cancellationToken);
    }
}