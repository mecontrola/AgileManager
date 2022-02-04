using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface ICalculateGrowthToDoInProgressHelper
    {
        IDictionary<GrowthTypes, IList<CFDInfoDto>> Execute(IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> values);
    }
}