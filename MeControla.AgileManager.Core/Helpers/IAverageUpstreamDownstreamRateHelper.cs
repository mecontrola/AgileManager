using MeControla.AgileManager.Core.Data.Dto;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface IAverageUpstreamDownstreamRateHelper
    {
        decimal Calculate(IList<AHMInfoDto> list);
    }
}