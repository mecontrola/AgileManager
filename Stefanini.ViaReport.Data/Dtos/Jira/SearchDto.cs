using System.Collections.Generic;

namespace Stefanini.ViaReport.Data.Dtos.Jira
{
    public class SearchDto : PaginationDto
    {
        public IList<IssueDto> Issues { get; set; }
    }
}