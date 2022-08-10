using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface IBaseStatusService
    {
        Task<IDictionary<string, string>> GetList(CancellationToken cancellationToken);
    }
}