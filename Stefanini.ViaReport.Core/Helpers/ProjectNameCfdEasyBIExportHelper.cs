using Stefanini.ViaReport.Core.Data.Dto;

namespace Stefanini.ViaReport.Core.Helpers
{
    public class ProjectNameCfdEasyBIExportHelper : IProjectNameCfdEasyBIExportHelper
    {
        public string Format(JiraProjectDto project)
            => $"[Project.Category].[{project.Category}].[{project.Name}]";
    }
}