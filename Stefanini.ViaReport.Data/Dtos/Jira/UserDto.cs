namespace Stefanini.ViaReport.Data.Dtos.Jira
{
    public class UserDto
    {
        public string Self { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public string TimeZone { get; set; }
    }
}