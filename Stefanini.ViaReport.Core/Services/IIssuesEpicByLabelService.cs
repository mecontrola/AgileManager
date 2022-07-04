using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface IIssuesEpicByLabelService
    {
        Task<SearchDto> GetData(string username, string password, string project, string[] labels, CancellationToken cancellationToken);
    }
}