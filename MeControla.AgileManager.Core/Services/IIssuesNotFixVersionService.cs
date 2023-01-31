using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface IIssuesNotFixVersionService
    {
        Task<SearchDto> GetData(string project, CancellationToken cancellationToken);
    }
}