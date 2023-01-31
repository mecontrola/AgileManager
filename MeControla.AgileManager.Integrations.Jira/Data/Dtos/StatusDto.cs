namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class StatusDto
    {
        public string Id { get; set; }
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusCategoryDto StatusCategory { get; set; }
    }
}