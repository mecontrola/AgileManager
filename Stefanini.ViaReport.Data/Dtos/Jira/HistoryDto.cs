using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Data.Dtos.Jira
{
    public class HistoryDto
    {
        public string Id { get; set; }
        public UserDto Author { get; set; }
        public DateTime Created { get; set; }
        public IList<HistoryItemDto> Items { get; set; }
    }
}