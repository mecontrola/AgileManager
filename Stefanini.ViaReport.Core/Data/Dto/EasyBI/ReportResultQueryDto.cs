using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto.EasyBI
{
    public class ReportResultQueryDto
    {
        public IList<List<ReportResultColumnPositionDto>> ColumnPositions { get; set; }
        public IList<List<ReportResultRowPositionDto>> RowPositions { get; set; }
        public IList<List<decimal?>> Values { get; set; }
        public IList<List<string>> FormattedValues { get; set; }
    }
}