using MeControla.AgileManager.Core.Data.Dto;
using MeControla.AgileManager.Core.Data.Enums;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface ICalculateGrowthToDoInProgressHelper
    {
        IDictionary<GrowthTypes, IList<CFDInfoDto>> Execute(IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>> values);
    }
}