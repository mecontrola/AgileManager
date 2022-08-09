using MeControla.AgileManager.Data.Enums;
using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Dtos
{
    public class DownstreamIndicatorDto
    {
        public decimal CycleBalance { get; set; }
        public IDictionary<DownstreamIndicatorTypes, IList<IssueDto>> Bugs { get; set; }
        public IDictionary<DownstreamIndicatorTypes, IList<IssueDto>> TechnicalDebit { get; set; }
    }
}
