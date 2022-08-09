using MeControla.AgileManager.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public interface IDashboardBusiness
    {
        Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
        Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(long projectId, long quarterId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}