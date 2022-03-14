using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto
{
    public class DeliveryLastCycleDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Throughtput { get; set; }
        public decimal LeadTimeAverage { get; set; }
        public IList<DeliveryLastCycleIssueDto> Issues { get; set; }
    }
}