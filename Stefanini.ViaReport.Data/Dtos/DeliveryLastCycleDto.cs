using Stefanini.ViaReport.Data.Entities;
using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Data.Dtos
{
    public class DeliveryLastCycleDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Throughtput { get; set; }
        public decimal CustomerLeadTimeAverage { get; set; }
        public decimal DiscoveryLeadTimeAverage { get; set; }
        public decimal SystemLeadTimeAverage { get; set; }
        public int Feature { get; set; }
        public decimal FeaturePercent { get; set; }
        public int Debits { get; set; }
        public decimal DebitsPercent { get; set; }
        public IDictionary<IssueType, int> ThroughtputType { get; set; }
        public IList<DeliveryLastCycleIssueDto> Issues { get; set; }
        public IList<DeliveryLastCycleImpedimentDto> Impediments { get; set; }
        public IList<DeliveryLastCycleEpicDto> Epics { get; set; }
    }
}