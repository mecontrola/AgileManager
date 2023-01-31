using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.IssueTypes
{
    public interface IIssueTypeGetAll
    {
        Task<IssueTypeDto[]> Execute(CancellationToken cancellationToken);
    }
}