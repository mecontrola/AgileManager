using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.ProjectSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.ProjectSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Key).HasColumnName(fields.Key).IsRequired();
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Selected).HasColumnName(fields.Selected);
            builder.Property(p => p.ProjectCategoryId).HasColumnName(fields.ProjectCategoryId);

            builder.HasOne(p => p.ProjectCategory)
                   .WithMany(p => p.Projects)
                   .HasForeignKey(p => p.ProjectCategoryId)
                   .IsRequired();
        }
    }
}