using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.ProjectCategorySchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.ProjectCategorySchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class ProjectCategoryConfiguration : IEntityTypeConfiguration<ProjectCategory>
    {
        public void Configure(EntityTypeBuilder<ProjectCategory> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Key).HasColumnName(fields.Key).IsRequired();
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(p => p.Projects)
                   .WithOne(p => p.ProjectCategory)
                   .HasForeignKey(p => p.ProjectCategoryId);
        }
    }
}