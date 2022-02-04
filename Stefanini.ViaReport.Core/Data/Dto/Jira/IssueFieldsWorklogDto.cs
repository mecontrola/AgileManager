using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class IssueFieldsWorklogDto : PaginationDto
    {
        public IList<WorklogDto> Worklogs { get; set; }
    }
}