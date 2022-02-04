using Stefanini.ViaReport.Core.Data.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface IUpstreamDownstreamRateBusiness
    {
        Task<IList<AHMInfoDto>> GetData(string username, string password, string projects, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}