using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface IBaseStatusService
    {
        Task<IDictionary<string, string>> GetList(string username, string password, CancellationToken cancellationToken);
    }
}