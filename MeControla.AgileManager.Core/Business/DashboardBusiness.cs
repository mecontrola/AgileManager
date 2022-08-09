using MeControla.AgileManager.Core.Services;
using MeControla.AgileManager.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Business
{
    public class DashboardBusiness : IDashboardBusiness
    {
        private readonly IDeliveryLastCycleService deliveryLastCycleService;

        public DashboardBusiness(IDeliveryLastCycleService deliveryLastCycleService)
        {
            this.deliveryLastCycleService = deliveryLastCycleService;
        }

        public async Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await deliveryLastCycleService.GetData(project, initDate, endDate, cancellationToken);

        public async Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(long projectId, long quarterId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await deliveryLastCycleService.GetData(projectId, quarterId, initDate, endDate, cancellationToken);
    }
}