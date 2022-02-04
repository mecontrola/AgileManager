namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class ProjectDto : JiraBaseDto
    {
        public string Expand { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public ProjectCategoryDto ProjectCategory { get; set; }
    }
}