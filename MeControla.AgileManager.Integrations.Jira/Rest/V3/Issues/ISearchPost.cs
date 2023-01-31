using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using MeControla.AgileManager.Integrations.Jira.Data.Dtos.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues
{
    public interface ISearchPost
    {
        Task<SearchDto> Execute(SearchInputDto request, CancellationToken cancellationToken);
    }
}