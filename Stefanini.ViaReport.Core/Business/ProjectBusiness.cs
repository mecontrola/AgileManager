using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public class ProjectBusiness : IProjectBusiness
    {
        private readonly IProjectService projectService;

        public ProjectBusiness(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public async Task<IList<ProjectDto>> ListAllWithCategoryAsync(CancellationToken cancellationToken)
            => await projectService.LoadAllAsync(cancellationToken);

        public async Task<IList<ProjectDto>> ListSelectedWithCategoryAsync(CancellationToken cancellationToken)
            => await projectService.LoadSelectedAsync(cancellationToken);

        public async Task<IList<long>> ListSelectedIdsAsync(CancellationToken cancellationToken)
            => await projectService.LoadSelectedIdsAsync(cancellationToken);

        public async Task<bool> SetSelectedByIdAsync(long[] id, CancellationToken cancellationToken)
            => await projectService.SetSelectedByIdAsync(id, cancellationToken);
    }
}