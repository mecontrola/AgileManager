using Stefanini.ViaReport.Core.Services;
using Stefanini.ViaReport.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public class DashboardBusiness : IDashboardBusiness
    {
        private readonly ISettingsService settingsService;
        private readonly IDeliveryLastCycleService deliveryLastCycleService;

        public DashboardBusiness(ISettingsService settingsService,
                                 IDeliveryLastCycleService deliveryLastCycleService)
        {
            this.settingsService = settingsService;
            this.deliveryLastCycleService = deliveryLastCycleService;
        }

        public async Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var settings = await settingsService.LoadDataAsync(cancellationToken);

            return await deliveryLastCycleService.GetData(settings.Username, settings.Password, project, initDate, endDate, cancellationToken);
        }

        public async Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(long projectId, DateTime initDate, DateTime endDate, string quarter, CancellationToken cancellationToken)
            => await deliveryLastCycleService.GetData(projectId, initDate, endDate, quarter, cancellationToken);
    }
}