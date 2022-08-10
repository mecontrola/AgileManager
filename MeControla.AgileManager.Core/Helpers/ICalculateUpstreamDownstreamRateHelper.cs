using MeControla.AgileManager.Core.Data.Dto;
using MeControla.AgileManager.Core.Data.Enums;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface ICalculateUpstreamDownstreamRateHelper
    {
        IList<AHMInfoDto> Execute(IDictionary<GrowthTypes, IList<CFDInfoDto>> data);
    }
}