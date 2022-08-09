using MeControla.AgileManager.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Integrations.Jira.V1.Auth
{
    public interface ISessionGet
    {
        Task<SessionDto> Execute(CancellationToken cancellationToken);
    }
}