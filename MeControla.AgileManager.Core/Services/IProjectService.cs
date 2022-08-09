using MeControla.AgileManager.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface IProjectService
    {
        Task<IList<ProjectDto>> LoadAllAsync(CancellationToken cancellationToken);
        Task<IList<ProjectDto>> LoadSelectedAsync(CancellationToken cancellationToken);
        Task<IList<long>> LoadSelectedIdsAsync(CancellationToken cancellationToken);
        Task<bool> SetSelectedByIdAsync(long[] id, CancellationToken cancellationToken);
    }
}