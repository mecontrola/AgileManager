using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.PreferenceStatusCategorySchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.PreferenceStatusCategorySchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class PreferenceStatusCategoryConfiguration : IEntityTypeConfiguration<PreferenceStatusCategory>
    {
        public void Configure(EntityTypeBuilder<PreferenceStatusCategory> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Type).HasColumnName(fields.Type).IsRequired();
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.StatusCategoryId).HasColumnName(fields.StatusCategoryId).IsRequired();
            builder.Property(p => p.ProjectId).HasColumnName(fields.ProjectId).IsRequired();

            builder.HasOne(p => p.StatusCategory)
                   .WithOne(p => p.Preference)
                   .HasForeignKey<PreferenceStatusCategory>(p => p.StatusCategoryId);

            builder.HasOne(p => p.Project)
                   .WithMany(p => p.PreferenceStatusCategory)
                   .HasForeignKey(p => p.ProjectId);
        }
    }
}