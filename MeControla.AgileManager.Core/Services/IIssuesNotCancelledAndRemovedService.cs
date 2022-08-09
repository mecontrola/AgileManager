using MeControla.AgileManager.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface IIssuesNotCancelledAndRemovedService
    {
        Task<SearchDto> GetData(string project, CancellationToken cancellationToken);
    }
}