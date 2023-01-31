using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.DataStorage.DataSeeding;
using Microsoft.EntityFrameworkCore;

namespace MeControla.AgileManager.DataStorage
{
    public class DbAppContext : DbContext, IDbAppContext
    {
        public DbSet<ClassOfService> ClasseOfServices { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<Deploy> Deploys { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueCustomfieldData> IssueCustomfieldDatas { get; set; }
        public DbSet<IssueEpic> IssueEpics { get; set; }
        public DbSet<IssueExtraData> IssueExtraDatas { get; set; }
        public DbSet<IssueImpediment> IssueImpediments { get; set; }
        public DbSet<IssueStatusHistory> IssueStatusHistories { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<PreferenceClassOfService> PreferenceClasseOfServices { get; set; }
        public DbSet<PreferenceCustomField> PreferenceCustomFields { get; set; }
        public DbSet<PreferenceIssueType> PreferenceIssueTypes { get; set; }
        public DbSet<PreferenceStatus> PreferenceStatuses { get; set; }
        public DbSet<PreferenceStatusCategory> PreferenceStatusCategories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Quarter> Quarters { get; set; }
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