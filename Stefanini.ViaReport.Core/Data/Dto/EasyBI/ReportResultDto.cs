using System;

namespace Stefanini.ViaReport.Core.Data.Dto.EasyBI
{
    public class ReportResultDto
    {
        public string ReportName { get; set; }
        public ReportResultQueryDto QueryResults { get; set; }
        public ReportResultDefinitionDto Definition { get; set; }
        public string CubeName { get; set; }
        public DateTime LastImportAt { get; set; }
    }
}