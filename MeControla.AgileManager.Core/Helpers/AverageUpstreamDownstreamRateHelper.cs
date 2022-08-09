using MeControla.AgileManager.Core.Data.Dto;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.AgileManager.Core.Helpers
{
    public class AverageUpstreamDownstreamRateHelper : IAverageUpstreamDownstreamRateHelper
    {
        public decimal Calculate(IList<AHMInfoDto> list)
            => list.Sum(itm => itm.UpstreamDownstreamRate ?? 0) / list.Count;
    }
}