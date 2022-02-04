using Stefanini.ViaReport.Core.Data.Dto.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V1.Auth
{
    public interface ISessionGet
    {
        Task<SessionDto> Execute(string username, string password, CancellationToken cancellationToken);
    }
}