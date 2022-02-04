using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Dto.Jira.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Projects
{
    public interface ISearchPost
    {
        Task<SearchDto> Execute(string username, string password, SearchInputDto request, CancellationToken cancellationToken);
    }
}