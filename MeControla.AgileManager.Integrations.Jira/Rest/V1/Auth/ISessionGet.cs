using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V1.Auth
{
    public interface ISessionGet
    {
        Task<SessionDto> Execute(CancellationToken cancellationToken);
    }
}