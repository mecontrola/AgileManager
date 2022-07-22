using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using Stefanini.ViaReport.Core.Mappers.DtoToEntity;
using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Dtos.Synchronizers;
using Stefanini.ViaReport.Data.Entities;
using Stefanini.ViaReport.DataStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services.Synchronizers
{
    public class ProjectSynchronizerService : IProjectSynchronizerService
    {
        private readonly IProjectRepository projectRepository;
        private readonly IProjectCategoryRepository projectCategoryRepository;

        private readonly IProjectGetAll projectGetAll;

        private readonly IJiraProjectDtoToEntityMapper jiraProjectDtoToEntityMapper;

        public ProjectSynchronizerService(IProjectRepository projectRepository,
                                          IProjectCategoryRepository projectCategoryRepository,
                                          IProjectGetAll projectGetAll,
                                          IJiraProjectDtoToEntityMapper jiraProjectDtoToEntityMapper)
        {
            this.projectRepository = projectRepository;
            this.projectCategoryRepository = projectCategoryRepository;
            this.projectGetAll = projectGetAll;
            this.jiraProjectDtoToEntityMapper = jiraProjectDtoToEntityMapper;
        }

        public async Task SynchronizeData(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
        {
            var projectsByJira = await LoadListFromJira(configurationSynchronizerDto, cancellationToken);
            var categoriesByLocal = await LoadProjectCategoriesFromDataBase(cancellationToken);
            var categoriesIdInJira = GetCategoryIdToArray(categoriesByLocal);
            var projects = SatinizeProjectByCategory(projectsByJira, categoriesIdInJira);

            foreach (var project in projects)
                await SaveProject(project, cancellationToken);
        }

        private async Task<IList<ProjectDto>> LoadListFromJira(ConfigurationSynchronizerDto configurationSynchronizerDto, CancellationToken cancellationToken)
            => await projectGetAll.Execute(configurationSynchronizerDto.Username, configurationSynchronizerDto.Password, cancellationToken);

        private async Task<IList<ProjectCategory>> LoadProjectCategoriesFromDataBase(CancellationToken cancellationToken)
            => await projectCategoryRepository.FindAllAsync(cancellationToken);

        private static long[] GetCategoryIdToArray(IList<ProjectCategory> categoriesByLocal)
            => categoriesByLocal.Select(x => x.Key)
                                .ToArray();

        private static IEnumerable<ProjectDto> SatinizeProjectByCategory(IList<ProjectDto> projectsByJira, long[] categoriesIdInJira)
            => projectsByJira.Where(itm => itm.ProjectCategory != null
                                        && categoriesIdInJira.Any(id => long.Parse(itm.ProjectCategory.Id).Equals(id)));

        private async Task SaveProject(ProjectDto project, CancellationToken cancellationToken)
        {
            if (await projectRepository.ExistsByKeyAsync(long.Parse(project.Id), cancellationToken))
                return;

            var category = await projectCategoryRepository.FindByKeyAsync(long.Parse(project.ProjectCategory.Id), cancellationToken);

            var entity = jiraProjectDtoToEntityMapper.ToMap(project);
            entity.Uuid = Guid.NewGuid();
            entity.ProjectCategoryId = category.Id;

            await projectRepository.CreateAsync(entity, cancellationToken);
        }
    }
}