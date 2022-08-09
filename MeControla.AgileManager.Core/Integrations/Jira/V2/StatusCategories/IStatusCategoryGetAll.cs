using MeControla.AgileManager.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.StatusCategories
{
    public interface IStatusCategoryGetAll
    {
        Task<StatusCategoryDto[]> Execute(CancellationToken cancellationToken);
    }
}