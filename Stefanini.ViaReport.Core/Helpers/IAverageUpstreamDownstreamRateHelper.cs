using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface IAverageUpstreamDownstreamRateHelper
    {
        decimal Calculate(IList<AHMInfoDto> list);
    }
}