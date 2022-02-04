using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface IJiraAuthService
    {
        Task<bool> IsAuthenticationOk(string username, string password, CancellationToken cancellationToken);
    }
}