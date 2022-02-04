using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface ICalculateUpstreamDownstreamRateHelper
    {
        IList<AHMInfoDto> Execute(IDictionary<GrowthTypes, IList<CFDInfoDto>> data);
    }
}