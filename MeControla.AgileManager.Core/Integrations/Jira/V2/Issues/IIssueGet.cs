using MeControla.AgileManager.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Integrations.Jira.V2.Issues
{
    public interface IIssueGet
    {
        Task<IssueDto> Execute(string issueKey, CancellationToken cancellationToken);
    }
}