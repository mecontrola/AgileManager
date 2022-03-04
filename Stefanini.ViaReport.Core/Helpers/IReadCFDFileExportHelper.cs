using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Helpers
{
    public interface IReadCFDFileExportHelper
    {
        Task<IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>>> GetData(string filename, CancellationToken cancellationToken);
    }
}