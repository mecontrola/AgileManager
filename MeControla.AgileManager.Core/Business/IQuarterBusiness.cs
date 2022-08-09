using MeControla.AgileManager.Data.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public interface IQuarterBusiness
    {
        Task<IList<QuarterDto>> ListAllAsync(CancellationToken cancellationToken);
    }
}