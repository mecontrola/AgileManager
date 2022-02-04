using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class ChangelogDto : PaginationDto
    {
        public IList<HistoryDto> Histories { get; set; }
    }
}