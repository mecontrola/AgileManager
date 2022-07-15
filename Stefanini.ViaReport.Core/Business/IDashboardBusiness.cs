using Stefanini.ViaReport.Core.Data.Dto;
using Stefanini.ViaReport.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Business
{
    public interface IDashboardBusiness
    {
        Task<DashboardDto> GetData(string project, string quarter, CancellationToken cancellationToken);
        Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
        Task<DeliveryLastCycleDto> GetDeliveryLastCycleData(long projectId, DateTime initDate, DateTime endDate, string quarter, CancellationToken cancellationToken);
    }
}