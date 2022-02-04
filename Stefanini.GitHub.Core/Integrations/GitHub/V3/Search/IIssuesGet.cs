using Stefanini.GitHub.Core.Data.Dto.GitHub;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.GitHub.Core.Integrations.GitHub.V3.Search
{
    public interface IIssuesGet
    {
        Task<SearchIssueDto> Execute(string username, string password, string query, CancellationToken cancellationToken);
    }
}