using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto
{
    public class DashboardInfoDto
    {
        public decimal Average { get; set; }
        public IList<DashboardInfoItemDto> Items { get; set; }
    }
}