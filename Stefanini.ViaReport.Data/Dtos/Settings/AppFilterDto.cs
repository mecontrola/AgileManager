using System;

namespace Stefanini.ViaReport.Data.Dtos.Settings
{
    public class AppFilterDto
    {
        public ProjectDto Project { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public QuarterDto Quarter { get; set; }
    }
}