using MeControla.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public interface IIssueRepository : IAsyncRepository<Issue>
    {
        Task<DateTime?> GetLastUpdatedAsync(long projectId, CancellationToken cancellationToken);
        Task<Issue> FindByKeyAsync(string key, CancellationToken cancellationToken);
    }
}