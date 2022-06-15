using Stefanini.ViaReport.Core.Data.Dto;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface IDownstreamJiraIndicatorsBusiness
    {
        Task<DownstreamJiraIndicatorsDto> GetData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}