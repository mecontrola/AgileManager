using Stefanini.ViaReport.Data.Dtos.Jira;
using Stefanini.ViaReport.Data.Dtos.Jira.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects
{
    public interface ISearchPost
    {
        Task<SearchDto> Execute(string username, string password, SearchInputDto request, CancellationToken cancellationToken);
    }
}