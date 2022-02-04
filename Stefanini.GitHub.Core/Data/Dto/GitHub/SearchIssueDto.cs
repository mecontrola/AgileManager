using System.Collections.Generic;

namespace Stefanini.GitHub.Core.Data.Dto.GitHub
{
    public class SearchIssueDto
    {
        public int TotalCount { get; set; }
        public bool IncompleteResults { get; set; }
        public IList<SearchIssueItemDto> Items { get; set; }
    }
}