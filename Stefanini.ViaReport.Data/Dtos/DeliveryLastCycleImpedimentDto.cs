using System;

namespace Stefanini.ViaReport.Data.Dtos
{
    public class DeliveryLastCycleImpedimentDto
    {
        public string Key { get; set; }
        public string IssueType { get; set; }
        public string Description { get; set; }
        public TimeSpan Time { get; set; }
        public string Link { get; set; }
    }
}