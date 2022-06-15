namespace Stefanini.ViaReport.Data.Dtos
{
    public class ProjectDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
        public ProjectCategoryDto Category { get; set; }
    }
}