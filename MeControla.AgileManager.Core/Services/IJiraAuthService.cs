using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface IJiraAuthService
    {
        Task<bool> IsAuthenticationOk(CancellationToken cancellationToken);
    }
}