using MeControla.AgileManager.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface IDeliveryLastCycleService
    {
        Task<DeliveryLastCycleDto> GetData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
        Task<DeliveryLastCycleDto> GetData(long projectId, long quarterId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}