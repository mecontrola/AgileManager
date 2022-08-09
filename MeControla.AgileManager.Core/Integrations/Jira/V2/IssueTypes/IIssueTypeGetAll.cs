using MeControla.AgileManager.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.IssueTypes
{
    public interface IIssueTypeGetAll
    {
        Task<IssueTypeDto[]> Execute(CancellationToken cancellationToken);
    }
}