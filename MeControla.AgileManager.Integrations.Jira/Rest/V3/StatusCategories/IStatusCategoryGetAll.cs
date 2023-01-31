using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.StatusCategories
{
    public interface IStatusCategoryGetAll
    {
        Task<StatusCategoryDto[]> Execute(CancellationToken cancellationToken);
    }
}