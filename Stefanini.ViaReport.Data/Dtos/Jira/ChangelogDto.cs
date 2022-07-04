using System.Collections.Generic;

namespace Stefanini.ViaReport.Data.Dtos.Jira
{
    public class ChangelogDto : PaginationDto
    {
        public IList<HistoryDto> Histories { get; set; }
    }
}