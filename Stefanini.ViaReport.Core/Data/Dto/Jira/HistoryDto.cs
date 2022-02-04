using System;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Data.Dto.Jira
{
    public class HistoryDto
    {
        public string Id { get; set; }
        public UserDto Author { get; set; }
        public DateTime Created { get; set; }
        public IList<HistoryItemDto> Items { get; set; }
    }
}