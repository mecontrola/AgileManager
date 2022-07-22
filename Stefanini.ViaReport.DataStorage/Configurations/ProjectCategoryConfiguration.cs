using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.DataStorage.Configurations
{
    internal class ProjectCategoryConfiguration : IEntityTypeConfiguration<ProjectCategory>
    {
        public void Configure(EntityTypeBuilder<ProjectCategory> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Key).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(p => p.Projects)
                   .WithOne(p => p.ProjectCategory)
                   .HasForeignKey(p => p.ProjectCategoryId);
        }
    }
}