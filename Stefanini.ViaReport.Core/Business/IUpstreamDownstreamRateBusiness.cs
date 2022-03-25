using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface IUpstreamDownstreamRateBusiness
    {
        Task<IList<AHMInfoDto>> GetData(string filename, CancellationToken cancellationToken);
    }
}