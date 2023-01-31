using MeControla.AgileManager.Data.Enums;

namespace MeControla.AgileManager.Data.Dtos
{
    public class DeliveryLastCycleIssueDto
    {
        public string Key { get; set; }
        public string IssueType { get; set; }
        public string Description { get; set; }
        public string ClassOfService { get; set; }
        public bool IsIncident { get; set; }
        public decimal StoryPoints { get; set; }
        public string Link { get; set; }
    }
}