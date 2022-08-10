namespace MeControla.AgileManager.Data.Dtos.Jira
{
    public class ProjectDto : JiraBaseDto
    {
        public string Expand { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public ProjectCategoryDto ProjectCategory { get; set; }
    }
}