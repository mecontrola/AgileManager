using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface IBaseIssuesInDateRangesService
    {
        Task<SearchDto> GetData(string project, DateTime initDate, DateTime endDate, CancellationToken cancellationToken);
    }
}