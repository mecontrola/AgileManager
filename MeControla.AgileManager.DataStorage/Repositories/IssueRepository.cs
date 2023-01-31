using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class IssueRepository : BaseAsyncRepository<Issue>, IIssueRepository
    {
        public IssueRepository(IDbAppContext context)
            : base(context, context.Issues)
        { }

        public async Task<DateTime?> GetLastUpdatedAsync(long projectId, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Where(entity => entity.ProjectId == projectId)
                          .OrderByDescending(entity => entity.Updated)
                          .Select(entity => (DateTime?)entity.Updated)
                          .FirstAsync(cancellationToken);

        public async Task<Issue> FindByKeyAsync(string key, CancellationToken cancellationToken)
            => await FindAsync(entity => entity.Key.Equals(key), cancellationToken);

        public async Task<IList<Issue>> FindAllInBacklogAsync(long projectId, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Status)
                          .Include(entity => entity.IssueType)
                          .Include(entity => entity.ExtraData)
                          .ThenInclude(entity => entity.ClassOfService)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Status.StatusCategory.Preference.Type == StatusCategories.ToDo
                                        && entity.Status.StatusCategory.Preference.ProjectId == entity.ProjectId
                                        && entity.IssueType.Preference.Type != IssueTypes.Epic
                                        && entity.IssueType.Preference.Type != IssueTypes.SubTask
                                        && entity.IssueType.Preference.ProjectId == entity.ProjectId)
                          .ToListAsync(cancellationToken);

        public async Task<IList<Issue>> FindAllInProgressAsync(long projectId, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Status)
                          .Include(entity => entity.IssueType)
                          .Include(entity => entity.ExtraData)
                          .ThenInclude(entity => entity.ClassOfService)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Status.StatusCategory.Preference.Type == StatusCategories.InProgress
                                        && entity.Status.StatusCategory.Preference.ProjectId == entity.ProjectId
                                        && entity.IssueType.Preference.Type != IssueTypes.Epic
                                        && entity.IssueType.Preference.Type != IssueTypes.Story
                                        && entity.IssueType.Preference.ProjectId == entity.ProjectId)
                          .ToListAsync(cancellationToken);

        public async Task<IList<Issue>> FindResolvedInDateRangeAsync(long projectId, DateTime resolvedInit, DateTime resolvedEnd, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Status)
                          .Include(entity => entity.IssueType)
                          .Include(entity => entity.Impediments)
                          .Include(entity => entity.ExtraData)
                          .ThenInclude(entity => entity.ClassOfService)
                          .ThenInclude(entity => entity.Preference)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Resolved != null
                                        && entity.Resolved.Value.Date >= resolvedInit.Date
                                        && entity.Resolved.Value.Date <= resolvedEnd.Date
                                        && entity.Status.StatusCategory.Preference.Type == StatusCategories.Done
                                        && entity.Status.StatusCategory.Preference.ProjectId == entity.ProjectId
                                        && entity.IssueType.Preference.Type != IssueTypes.Epic
                                        && entity.IssueType.Preference.Type != IssueTypes.Story
                                        && entity.IssueType.Preference.ProjectId == entity.ProjectId
                                        && (context as IDbAppContext).PreferenceStatuses.Any(any => any.StatusId == entity.StatusId))
                          .OrderBy(entity => entity.Key)
                          .ToListAsync(cancellationToken);

        public async Task<decimal> GetCycleBalanceAsync(long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.IssueType)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Created.Date >= createdInit.Date
                                        && entity.Created.Date <= createdEnd.Date
                                        && entity.Status.Key != (long)StatusTypes.Removed
                                        && entity.Status.Key != (long)StatusTypes.Cancelled
                                        && (entity.IssueType.Key == (long)IssueTypes.Bug
                                        || entity.IssueType.Key == (long)IssueTypes.Task
                                        || entity.IssueType.Key == (long)IssueTypes.Story
                                        || entity.IssueType.Key == (long)IssueTypes.TechnicalDebt
                                        || entity.IssueType.Key == (long)IssueTypes.Improvement))
                          .Select(entity => new
                          {
                              Group = true,
                              IsFeature = entity.IssueType.Key == (long)IssueTypes.Story
                          })
                          .GroupBy(group => group.Group)
                          .Select(group => group.Where(x => x.IsFeature).Count() / (decimal)group.Count() * 100)
                          .Select(data => Math.Round(data, 2))
                          .FirstOrDefaultAsync(cancellationToken);

        public async Task<IList<Issue>> GetIssuesCancelledInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Status)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Resolved != null
                                        && entity.Resolved.Value.Date >= createdInit.Date
                                        && entity.Resolved.Value.Date <= createdEnd.Date
                                        && (entity.Status.Key == (long)StatusTypes.Removed || entity.Status.Key == (long)StatusTypes.Cancelled)
                                        && entity.IssueType.Key == (long)issueTypes)
                          .ToListAsync(cancellationToken);

        public async Task<IList<Issue>> GetIssuesCreatedAndResolvedInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Status)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Created.Date >= createdInit.Date
                                        && entity.Created.Date <= createdEnd.Date
                                        && entity.Resolved != null
                                        && entity.Resolved.Value.Date >= createdInit.Date
                                        && entity.Resolved.Value.Date <= createdEnd.Date
                                        && entity.Status.Key == (long)StatusTypes.Done
                                        && entity.IssueType.Key == (long)issueTypes)
                          .ToListAsync(cancellationToken);

        public async Task<IList<Issue>> GetIssuesCreatedInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Status)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Created.Date >= createdInit.Date
                                        && entity.Created.Date <= createdEnd.Date
                                        && entity.IssueType.Key == (long)issueTypes)
                          .ToListAsync(cancellationToken);

        public async Task<IList<Issue>> GetIssuesExistedInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Status)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Created.Date <= createdInit.Date
                                        && (entity.Resolved == null
                                        || (entity.Resolved != null && entity.Resolved.Value.Date >= createdInit.Date
                                                                    && entity.Resolved.Value.Date <= createdEnd.Date)
                                        || (entity.Resolved != null && entity.Resolved.Value.Date >= createdEnd.Date))
                                        && entity.IssueType.Key == (long)issueTypes
                                        && entity.Status.Key != (long)StatusTypes.Removed
                                        && entity.Status.Key != (long)StatusTypes.Cancelled)
                          .ToListAsync(cancellationToken);

        public async Task<IList<Issue>> GetIssuesOpenedInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Status)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Created.Date >= createdInit.Date
                                        && entity.Created.Date <= createdEnd.Date
                                        && (entity.Resolved == null
                                        || (entity.Resolved != null && entity.Resolved.Value.Date >= createdEnd.Date))
                                        && entity.Status.StatusCategory.Key != (long)StatusCategories.Done
                                        && entity.IssueType.Key == (long)issueTypes)
                          .ToListAsync(cancellationToken);

        public async Task<IList<Issue>> GetIssuesResolvedInDateRangeByIssueTypeAsync(IssueTypes issueTypes, long projectId, DateTime createdInit, DateTime createdEnd, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Status)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Resolved != null
                                        && entity.Resolved.Value.Date >= createdInit.Date
                                        && entity.Resolved.Value.Date <= createdEnd.Date
                                        && entity.Status.Key == (long)StatusTypes.Done
                                        && entity.IssueType.Key == (long)issueTypes)
                          .ToListAsync(cancellationToken);

        public async Task<IList<Issue>> GetIssuesBackendToDeployAsync(long projectId, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Statuses)
                          .Include(entity => entity.Deploy)
                          .Where(entity => entity.ProjectId == projectId
                                        && entity.Summary.ToLower().Contains("[Backend]".ToLower())
                                        && entity.Statuses.Any(history => history.FromStatusId == 71
                                                                       && (history.ToStatusId == 52 || history.ToStatusId == 72))
                                        && entity.IssueType.Preference.Type != IssueTypes.SubTask)
                          .ToListAsync(cancellationToken);

    }
}