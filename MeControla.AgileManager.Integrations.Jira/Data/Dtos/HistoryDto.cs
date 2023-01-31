using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class HistoryDto
    {
        public string Id { get; set; }
        public UserDto Author { get; set; }
        public DateTime Created { get; set; }
        public IList<HistoryItemDto> Items { get; set; }
    }
}