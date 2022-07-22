using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.Issues
{
    public interface IIssueGet
    {
        Task<IssueDto> Execute(string username, string password, string issueKey, CancellationToken cancellationToken);
    }
}