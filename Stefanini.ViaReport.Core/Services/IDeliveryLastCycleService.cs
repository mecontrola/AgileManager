using Stefanini.ViaReport.Core.Data.Dto;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public interface IDeliveryLastCycleService
    {
        Task<DeliveryLastCycleDto> GetData(string username, string password, string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}