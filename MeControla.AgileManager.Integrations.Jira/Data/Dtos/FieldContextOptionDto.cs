using System.Collections.Generic;

namespace MeControla.AgileManager.Integrations.Jira.Data.Dtos
{
    public class FieldContextOptionDto : PaginationDto
    {
        public IList<OptionDto> Values { get; set; }
    }
}