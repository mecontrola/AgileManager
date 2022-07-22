using Microsoft.EntityFrameworkCore;
using Stefanini.ViaReport.Data.Entities;
using Stefanini.ViaReport.DataStorage.DataSeeding;

namespace Stefanini.ViaReport.DataStorage
{
    public class DbAppContext : DbContext, IDbAppContext
    {
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueEpic> IssueEpics { get; set; }
        public DbSet<IssueImpediment> IssueImpediments { get; set; }
        public DbSet<IssueStatusHistory> IssueStatusHistories { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StatusCategory> StatusCategories { get; set; }

        public DbAppContext(DbContextOptions<DbAppContext> options)
            : base(options)
        {
            if (Database.IsRelational())
                Database.Migrate();
            else
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbAppContext).Assembly);
            modelBuilder.Seed();
        }
    }
}