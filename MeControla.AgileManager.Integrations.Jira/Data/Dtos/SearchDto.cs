using System.Collections.Generic;

namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class SearchDto : PaginationDto
    {
        public IList<IssueDto> Issues { get; set; }
    }
}