using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Dtos.Jira
{
    public class ChangelogDto : PaginationDto
    {
        public IList<HistoryDto> Histories { get; set; }
    }
}