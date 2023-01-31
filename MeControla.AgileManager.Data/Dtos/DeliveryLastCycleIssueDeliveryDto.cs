namespace MeControla.AgileManager.Data.Dtos
{
    public class DeliveryLastCycleIssueDeliveryDto : DeliveryLastCycleIssueDto
    {
        public decimal CustomerLeadTime { get; set; }
        public decimal DiscoveryLeadTime { get; set; }
        public decimal SystemLeadTime { get; set; }
        public bool IsFeature { get; set; }
        public decimal InDevelop { get; set; }
        public decimal ToTest { get; set; }
        public decimal InTest { get; set; }
        public decimal ToHomolog { get; set; }
        public decimal InHomolog { get; set; }
    }
}