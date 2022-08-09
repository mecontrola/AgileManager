using MeControla.AgileManager.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public interface IDownstreamJiraIndicatorsBusiness
    {
        Task<DownstreamIndicatorDto> GetLocalIndicatorsAsync(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
        Task<DownstreamIndicatorDto> GetJiraIndicatorsAsync(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}