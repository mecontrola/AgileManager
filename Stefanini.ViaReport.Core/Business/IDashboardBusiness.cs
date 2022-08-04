using Stefanini.ViaReport.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface IDashboardBusiness
    {
        Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
        Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(long projectId, long quarterId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}