using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Options
{
    public interface IOptionGetAll
    {
        Task<FieldContextOptionDto> Execute(string fieldId, string contextId, CancellationToken cancellationToken);
    }
}