using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.PreferenceStatusSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.PreferenceStatusSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class PreferenceStatusConfiguration : IEntityTypeConfiguration<PreferenceStatus>
    {
        public void Configure(EntityTypeBuilder<PreferenceStatus> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Order).HasColumnName(fields.Order).HasDefaultValue(0);
            builder.Property(p => p.Progress).HasColumnName(fields.Progress).HasDefaultValue(0);
            builder.Property(p => p.StatusId).HasColumnName(fields.StatusId);
            builder.Property(p => p.ProjectId).HasColumnName(fields.ProjectId);

            builder.HasOne(p => p.Status)
                   .WithOne(p => p.Preference)
                   .HasForeignKey<PreferenceStatus>(p => p.StatusId);

            builder.HasOne(p => p.Project)
                   .WithMany(p => p.PreferenceStatus)
                   .HasForeignKey(p => p.ProjectId);
        }
    }
}