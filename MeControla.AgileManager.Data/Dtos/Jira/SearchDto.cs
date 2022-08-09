using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Dtos.Jira
{
    public class SearchDto : PaginationDto
    {
        public IList<IssueDto> Issues { get; set; }
    }
}