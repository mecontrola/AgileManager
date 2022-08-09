using MeControla.AgileManager.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface IDownstreamIndicatorsService
    {
        Task<DownstreamIndicatorDto> GetData(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}