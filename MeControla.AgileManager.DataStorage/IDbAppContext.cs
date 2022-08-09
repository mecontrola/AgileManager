using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeControla.AgileManager.DataStorage
{
    public interface IDbAppContext : IDbContext
    {
        DbSet<Issue> Issues { get; }
        DbSet<IssueEpic> IssueEpics { get; }
        DbSet<IssueImpediment> IssueImpediments { get; }
        DbSet<IssueStatusHistory> IssueStatusHistories { get; }
        DbSet<IssueType> IssueTypes { get; }
        DbSet<Project> Projects { get; }
        DbSet<ProjectCategory> ProjectCategories { get; }
        DbSet<Quarter> Quarters { get; }
        DbSet<Status> Statuses { get; }
        DbSet<StatusCategory> StatusCategories { get; }
    }
}