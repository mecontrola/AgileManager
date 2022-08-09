using MeControla.AgileManager.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.Statuses
{
    public interface IStatusGetAll
    {
        Task<StatusDto[]> Execute(CancellationToken cancellationToken);
    }
}