using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.DataStorage
{
    public interface IDbAppContext : IDbContext
    {
        DbSet<Issue> Issues { get; }
        DbSet<IssueStatusHistory> IssueStatusHistories { get; }
        DbSet<IssueType> IssueTypes { get; }
        DbSet<Project> Projects { get; }
        DbSet<ProjectCategory> ProjectCategories { get; }
        DbSet<Status> Statuses { get; }
        DbSet<StatusCategory> StatusCategories { get; }
    }
}