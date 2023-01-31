using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues
{
    public interface IIssueGet
    {
        Task<IssueDto> Execute(string issueKey, CancellationToken cancellationToken);
    }
}