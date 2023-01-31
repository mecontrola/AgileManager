using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.PreferenceCustomFieldSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.PreferenceCustomFieldSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class PreferenceCustomFieldConfiguration : IEntityTypeConfiguration<PreferenceCustomField>
    {
        public void Configure(EntityTypeBuilder<PreferenceCustomField> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Type).HasColumnName(fields.Type).IsRequired();
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.CustomFieldId).HasColumnName(fields.CustomFieldId).IsRequired();
            builder.Property(p => p.ProjectId).HasColumnName(fields.ProjectId).IsRequired();

            builder.HasOne(p => p.CustomField)
                   .WithOne(p => p.Preference)
                   .HasForeignKey<PreferenceCustomField>(p => p.CustomFieldId);

            builder.HasOne(p => p.Project)
                   .WithMany(p => p.PreferenceCustomField)
                   .HasForeignKey(p => p.ProjectId);
        }
    }
}