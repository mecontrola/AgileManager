using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Fields
{
    public interface IFieldGetAll
    {
        Task<FieldDto[]> Execute(CancellationToken cancellationToken);
    }
}