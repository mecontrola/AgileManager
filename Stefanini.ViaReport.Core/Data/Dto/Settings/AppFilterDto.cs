using System;

namespace Stefanini.ViaReport.Core.Data.Dto.Settings
{
    public class AppFilterDto
    {
        public JiraProjectDto Project { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Quarter { get; set; }
    }
}