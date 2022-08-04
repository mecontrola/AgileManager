using Stefanini.ViaReport.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface IDeliveryLastCycleService
    {
        Task<DeliveryLastCycleDto> GetData(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
        Task<DeliveryLastCycleDto> GetData(long projectId, long quarterId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}