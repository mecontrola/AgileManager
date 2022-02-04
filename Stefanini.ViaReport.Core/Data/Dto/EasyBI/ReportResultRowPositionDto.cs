using System;

namespace Stefanini.ViaReport.Core.Data.Dto.EasyBI
{
    public class ReportResultRowPositionDto
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool Drillable { get; set; }
        public int Depth { get; set; }
        public DateTime StartDate { get; set; }
    }
}