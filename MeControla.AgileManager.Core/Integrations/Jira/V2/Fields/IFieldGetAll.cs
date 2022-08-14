using MeControla.AgileManager.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.Fields
{
    public interface IFieldGetAll
    {
        Task<FieldDto[]> Execute(CancellationToken cancellationToken);
    }
}