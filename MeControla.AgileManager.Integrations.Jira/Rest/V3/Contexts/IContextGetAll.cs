using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Contexts
{
    public interface IContextGetAll
    {
        Task<FieldContextDto> Execute(string fieldId, CancellationToken cancellationToken);
    }
}