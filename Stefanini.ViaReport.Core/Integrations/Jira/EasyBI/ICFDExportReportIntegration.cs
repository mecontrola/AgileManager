using Stefanini.ViaReport.Core.Data.Dto.EasyBI;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Integrations.Jira.EasyBI
{
    public interface ICFDExportReportIntegration
    {
        Task<ReportResultDto> Execute(string username, string password, string accountId, string reportId, string reportFormat, string projects, string dates, CancellationToken cancellationToken);
    }
}