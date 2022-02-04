using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public class JiraProjectsService : IJiraProjectsService
    {
        private static readonly string[] AVAILABLE_TRIBES = new[] { "Descoberta", "Decisão", "Aplicativos", "Fidelização" };

        private readonly IProjectGetAll projectGetAll;

        public JiraProjectsService(IProjectGetAll projectGetAll)
        {
            this.projectGetAll = projectGetAll;
        }

        public async Task<IList<JiraProjectDto>> LoadList(string username, string password, CancellationToken cancellationToken)
        {
            var data = await projectGetAll.Execute(username, password, cancellationToken);

            return MountProjectList(data);
        }

        private static IList<JiraProjectDto> MountProjectList(ProjectDto[] projects)
            => projects.Where(itm => IsAvaliableProject(itm))
                       .Select(itm => new JiraProjectDto
                       {
                           Name = itm.Name,
                           Category = itm.ProjectCategory.Name
                       })
                       .OrderBy(itm => itm.Category)
                       .ThenBy(itm => itm.Name)
                       .ToList();

        private static bool IsAvaliableProject(ProjectDto project)
            => project.ProjectCategory != null
            && AVAILABLE_TRIBES.Any(elm => project.ProjectCategory.Name.StartsWith(elm));
    }
}