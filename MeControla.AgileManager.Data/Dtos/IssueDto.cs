using System;

namespace MeControla.AgileManager.Data.Dtos
{
    public class IssueDto
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Resolved { get; set; }
        public string Link { get; set; }
    }
}