using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.PreferenceClassOfServiceSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.PreferenceClassOfServiceSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class PreferenceClassOfServiceConfiguration : IEntityTypeConfiguration<PreferenceClassOfService>
    {
        public void Configure(EntityTypeBuilder<PreferenceClassOfService> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Type).HasColumnName(fields.Type).IsRequired();
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ClassOfServiceId).HasColumnName(fields.ClassOfServiceId).IsRequired();
            builder.Property(p => p.ProjectId).HasColumnName(fields.ProjectId).IsRequired();

            builder.HasOne(p => p.ClassOfService)
                   .WithOne(p => p.Preference)
                   .HasForeignKey<PreferenceClassOfService>(p => p.ClassOfServiceId);

            builder.HasOne(p => p.Project)
                   .WithMany(p => p.PreferenceClassOfService)
                   .HasForeignKey(p => p.ProjectId);
        }
    }
}