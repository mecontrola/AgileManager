using MeControla.AgileManager.Core.Mappers.DtoToEntity;
using MeControla.AgileManager.Data.Dtos.Synchronizers;
using MeControla.AgileManager.DataStorage.Repositories;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Projects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers
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
            var projects = await LoadListFromJira(cancellationToken);

            foreach (var project in projects)
                await SaveProject(project, cancellationToken);
        }

        private async Task<IList<ProjectDto>> LoadListFromJira(CancellationToken cancellationToken)
            => await projectGetAll.Execute(cancellationToken);

        private async Task SaveProject(ProjectDto project, CancellationToken cancellationToken)
        {
            if (await projectRepository.ExistsByKeyAsync(long.Parse(project.Id), cancellationToken))
                return;

            var projectCategoryKey = GetProjectCategoryKey(project.ProjectCategory);
            var category = await projectCategoryRepository.FindByKeyAsync(projectCategoryKey, cancellationToken);

            var entity = jiraProjectDtoToEntityMapper.ToMap(project);
            entity.Uuid = Guid.NewGuid();
            entity.ProjectCategoryId = category.Id;

            await projectRepository.CreateAsync(entity, cancellationToken);
        }

        private static long GetProjectCategoryKey(ProjectCategoryDto projectCategory)
            => projectCategory != null
             ? long.Parse(projectCategory.Id)
             : 0;
    }
}