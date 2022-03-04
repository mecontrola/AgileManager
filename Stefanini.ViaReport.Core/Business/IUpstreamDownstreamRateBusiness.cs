using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Core.Data.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface IUpstreamDownstreamRateBusiness
    {
        Task<IDictionary<EasyBIReportColumnName, IList<CFDInfoDto>>> GetPreData(string username, string password, string projects, CancellationToken cancellationToken);
        Task<IList<AHMInfoDto>> GetData(string username, string password, string projects, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
        Task<IList<AHMInfoDto>> GetData(string filename, CancellationToken cancellationToken);
    }
}