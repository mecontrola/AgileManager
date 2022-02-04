using System;

namespace Stefanini.ViaReport.Core.Data.Dto
{
    public class IssueInfoDto
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Resolved { get; set; }
        public string Link { get; set; }
    }
}