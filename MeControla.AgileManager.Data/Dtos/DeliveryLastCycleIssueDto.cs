namespace MeControla.AgileManager.Data.Dtos
{
    public class DeliveryLastCycleIssueDto
    {
        public string Key { get; set; }
        public string IssueType { get; set; }
        public string Description { get; set; }
        public decimal CustomerLeadTime { get; set; }
        public decimal DiscoveryLeadTime { get; set; }
        public decimal SystemLeadTime { get; set; }
        public bool IsFeature { get; set; }
        public string Link { get; set; }
    }
}