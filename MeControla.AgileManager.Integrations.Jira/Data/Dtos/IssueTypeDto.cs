namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class IssueTypeDto : BaseDto
    {
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public bool Subtask { get; set; }
        public long AvatarId { get; set; }
    }
}