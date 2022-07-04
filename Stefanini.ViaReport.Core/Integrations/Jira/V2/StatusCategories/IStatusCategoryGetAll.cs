using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.StatusCategories
{
    public interface IStatusCategoryGetAll
    {
        Task<StatusCategoryDto[]> Execute(string username, string password, CancellationToken cancellationToken);
    }
}