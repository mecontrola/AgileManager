using Stefanini.ViaReport.Data.Dtos.Jira;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface IBaseIssuesInDateRangesService
    {
        Task<SearchDto> GetData(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}