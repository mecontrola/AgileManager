using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Projects
{
    public interface IProjectGetAll
    {
        Task<ProjectDto[]> Execute(CancellationToken cancellationToken);
    }
}