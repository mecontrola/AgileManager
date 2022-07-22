using Stefanini.ViaReport.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface IDownstreamJiraIndicatorsService
    {
        Task<DownstreamIndicatorDto> GetData(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}