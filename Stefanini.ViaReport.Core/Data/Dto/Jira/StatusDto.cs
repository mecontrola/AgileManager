namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class StatusDto
    {
        public string Id { get; set; }
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public string UntranslateName { get; set; }
        public string Description { get; set; }
        public StatusCategoryDto StatusCategory { get; set; }
    }
}