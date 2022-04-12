using System;

namespace Stefanini.Core.Data.Dto.Settings
{
    public class AppFilterDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Quarter { get; set; }
    }
}