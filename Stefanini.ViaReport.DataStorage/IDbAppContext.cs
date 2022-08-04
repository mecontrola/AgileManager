using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.DataStorage
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