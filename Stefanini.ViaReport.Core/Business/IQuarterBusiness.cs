using Stefanini.ViaReport.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface IQuarterBusiness
    {
        Task<IList<QuarterDto>> ListAllAsync(CancellationToken cancellationToken);
    }
}