using Stefanini.ViaReport.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.V2.IssueTypes
{
    public interface IIssueTypeGetAll
    {
        Task<IssueTypeDto[]> Execute(string username, string password, CancellationToken cancellationToken);
    }
}