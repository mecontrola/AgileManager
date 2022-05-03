using Microsoft.EntityFrameworkCore;
using Stefanini.ViaReport.Data.Entities;
using Stefanini.ViaReport.DataStorage.DataSeeding;

namespace Stefanini.ViaReport.DataStorage
{
    public class DbAppContext : DbContext, IDbAppContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }

        public DbAppContext(DbContextOptions<DbAppContext> options)
            : base(options)
        {
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