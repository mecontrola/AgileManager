namespace Stefanini.ViaReport.Core.Data.Dto
{
    public class DashboardDto
    {
        public DashboardInfoDto Throughput { get; set; }
        public DashboardInfoDto LeadTime { get; set; }
        public DashboardInfoDto CycleTime { get; set; }
        public DashboardInfoDto QuarterEpics { get; set; }
    }
}