using Stefanini.ViaReport.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface IQuarterService
    {
        Task<IList<QuarterDto>> LoadAllAsync(CancellationToken cancellationToken);
    }
}