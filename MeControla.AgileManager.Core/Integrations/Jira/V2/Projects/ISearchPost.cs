using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Dtos.Jira.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.Projects
{
    public interface ISearchPost
    {
        Task<SearchDto> Execute(SearchInputDto request, CancellationToken cancellationToken);
    }
}