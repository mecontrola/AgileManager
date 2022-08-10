using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.DataStorage.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        private readonly IProjectEntityToDtoMapper projectEntityToDtoMapper;

        public ProjectService(IProjectRepository projectRepository,
                              IProjectEntityToDtoMapper projectEntityToDtoMapper)
        {
            this.projectRepository = projectRepository;
            this.projectEntityToDtoMapper = projectEntityToDtoMapper;
        }

        public async Task<IList<ProjectDto>> LoadAllAsync(CancellationToken cancellationToken)
        {
            var data = await projectRepository.FindAllWithCategoryAsync(cancellationToken);

            return MountProjectListAsync(data);
        }

        public async Task<IList<ProjectDto>> LoadSelectedAsync(CancellationToken cancellationToken)
        {
            var data = await projectRepository.FindSelectedWithCategoryAsync(cancellationToken);

            return MountProjectListAsync(data);
        }

        private IList<ProjectDto> MountProjectListAsync(IList<Project> projects)
            => projects.Select(itm => projectEntityToDtoMapper.ToMap(itm))
                       .OrderBy(itm => itm.Category.Name)
                       .ThenBy(itm => itm.Name)
                       .ToList();

        public async Task<IList<long>> LoadSelectedIdsAsync(CancellationToken cancellationToken)
            => await projectRepository.RetrieveSelectedIdsAsync(cancellationToken);

        public async Task<bool> SetSelectedByIdAsync(long[] id, CancellationToken cancellationToken)
        {
            await projectRepository.UpdateAllToNoSelectedAsync(cancellationToken);

            await projectRepository.UpdateToSelectedByIdsAsync(id, cancellationToken);

            return true;
        }
    }
}