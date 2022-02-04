using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs
{
    public class SearchInputDto
    {
        public string Jql { get; set; }
        public long StartAt { get; set; }
        public long MaxResults { get; set; }
        public IList<string> Fields { get; set; }
    }
}