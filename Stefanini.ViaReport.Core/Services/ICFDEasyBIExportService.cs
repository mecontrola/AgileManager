using Stefanini.ViaReport.Core.Data.Dto.EasyBI;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface ICFDEasyBIExportService
    {
        Task<ReportResultDto> GetReportData(string username, string password, string projects, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}