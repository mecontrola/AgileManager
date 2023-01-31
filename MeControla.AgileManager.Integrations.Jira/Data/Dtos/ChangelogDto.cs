using System.Collections.Generic;

namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class ChangelogDto : PaginationDto
    {
        public IList<HistoryDto> Histories { get; set; }
    }
}