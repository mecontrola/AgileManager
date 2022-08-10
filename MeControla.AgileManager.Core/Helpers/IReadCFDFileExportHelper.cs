using MeControla.AgileManager.Core.Data.Dto;
using MeControla.AgileManager.Core.Data.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface IReadCFDFileExportHelper
    {
        Task<IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>>> GetData(string filename, CancellationToken cancellationToken);
    }
}