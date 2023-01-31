namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class PaginationDto
    {
        public long StartAt { get; set; }
        public long MaxResults { get; set; }
        public long Total { get; set; }
    }
}