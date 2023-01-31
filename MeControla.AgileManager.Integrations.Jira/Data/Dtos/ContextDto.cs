namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class ContextDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsGlobalContext { get; set; }
        public bool IsAnyIssueType { get; set; }
    }
}