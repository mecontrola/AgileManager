using MeControla.AgileManager.Data.Entities;
using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Dtos
{
    public class DeliveryLastCycleDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Throughtput { get; set; }
        public decimal ThroughtputStoryPoints { get; set; }
        public decimal CustomerLeadTimeAverage { get; set; }
        public decimal DiscoveryLeadTimeAverage { get; set; }
        public decimal SystemLeadTimeAverage { get; set; }
        public int Feature { get; set; }
        public decimal FeaturePercent { get; set; }
        public int Debits { get; set; }
        public decimal DebitsPercent { get; set; }
        public int Standard { get; set; }
        public decimal StandardPercent { get; set; }
        public int Expedite { get; set; }
        public decimal ExpeditePercent { get; set; }
        public int FixedDate { get; set; }
        public decimal FixedDatePercent { get; set; }
        public int Intangible { get; set; }
        public decimal IntangiblePercent { get; set; }
        public decimal QuarterAveragePercentage { get; set; }
        public IDictionary<IssueType, int> ThroughtputType { get; set; }
        public IList<DeliveryLastCycleCycleTimeDto> CycleTime { get; set; }
        public IList<DeliveryLastCycleIssueDeliveryDto> IssuesDelivery { get; set; }
        public IList<DeliveryLastCycleIssueInProgressDto> IssuesInProgress { get; set; }
        public IList<DeliveryLastCycleImpedimentDto> Impediments { get; set; }
        public IList<DeliveryLastCycleEpicDto> Epics { get; set; }
    }
}