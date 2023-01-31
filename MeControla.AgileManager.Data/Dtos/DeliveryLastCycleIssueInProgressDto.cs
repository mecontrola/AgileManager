using System;

namespace MeControla.AgileManager.Data.Dtos
{
    public class DeliveryLastCycleIssueInProgressDto : DeliveryLastCycleIssueDto
    {
        public string Status { get; set; }
        public decimal Age { get; set; }
        public DateTime Estimate { get; set; }
        public string EstimateStr { get; set; }
        public bool Impediment { get; set; }
        public string Labels { get; set; }
    }
}