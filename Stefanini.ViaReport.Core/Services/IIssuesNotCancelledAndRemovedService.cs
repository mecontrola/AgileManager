using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface IIssuesNotCancelledAndRemovedService
    {
        Task<SearchDto> GetData(string username, string password, string project, CancellationToken cancellationToken);
    }
}