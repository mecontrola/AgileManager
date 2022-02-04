using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class SearchDto : PaginationDto
    {
        public IList<IssueDto> Issues { get; set; }
    }
}