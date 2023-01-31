using System.Collections.Generic;

namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class FieldContextDto : PaginationDto
    {
        public IList<ContextDto> Values { get; set; }
    }
}