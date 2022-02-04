namespace Stefanini.ViaReport.Core.Data.Dto.EasyBI
{
    public class ReportResultColumnPositionDto
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public int Depth { get; set; }
        public string FormatString { get; set; }
        public bool Calculated { get; set; }
        public int Span { get; set; }
        public bool Drillable { get; set; }
        public ReportResultColumnPositionAnnotationDto Annotations { get; set; }
    }
}