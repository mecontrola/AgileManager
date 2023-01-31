using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public interface IIssueStatusHistoryRepository : IAsyncRepository<IssueStatusHistory>
    {
        Task<bool> ExistsByIssueAndStatusAsync(long issueId, long statusId, CancellationToken cancellationToken);
        Task<DateTime?> FindDateTimeFirstHistoryByStatusCategoryAsync(long issueId, StatusCategories statusCategories, CancellationToken cancellationToken);
        Task<IList<IssueStatusHistory>> FindIssuesByProjectAndRangeDateTimeAsync(long projectId, DateTime init, DateTime end, CancellationToken cancellationToken);
        Task<IList<IssueStatusHistory>> FindAllStatusCategoryInProgressAsync(long issueId, CancellationToken cancellationToken);
    }
}