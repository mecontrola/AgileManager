using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IIssueRepository : IAsyncRepository<Issue>
    {
        Task<DateTime?> GetLastUpdatedAsync(long projectId, CancellationToken cancellationToken);
        Task<Issue> FindByKeyAsync(string key, CancellationToken cancellationToken);
        Task<IList<Issue>> FindResolvedInDateRangeAsync(long projectId, DateTime resolvedInit, DateTime resolvedEnd, CancellationToken cancellationToken);
        Task<decimal> GetCycleBalanceAsync(long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken);
        Task<IList<Issue>> GetIssuesCancelledInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken);
        Task<IList<Issue>> GetIssuesCreatedAndResolvedInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken);
        Task<IList<Issue>> GetIssuesCreatedInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken);
        Task<IList<Issue>> GetIssuesExistedInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken);
        Task<IList<Issue>> GetIssuesOpenedInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken);
        Task<IList<Issue>> GetIssuesResolvedInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken);
    }
}