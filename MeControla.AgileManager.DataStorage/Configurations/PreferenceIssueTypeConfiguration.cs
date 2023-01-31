using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.PreferenceIssueTypeSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.PreferenceIssueTypeSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class PreferenceIssueTypeConfiguration : IEntityTypeConfiguration<PreferenceIssueType>
    {
        public void Configure(EntityTypeBuilder<PreferenceIssueType> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Type).HasColumnName(fields.Type).IsRequired();
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.IssueTypeId).HasColumnName(fields.IssueTypeId);
            builder.Property(p => p.ProjectId).HasColumnName(fields.ProjectId).IsRequired();

            builder.HasOne(p => p.IssueType)
                   .WithOne(p => p.Preference)
                   .HasForeignKey<PreferenceIssueType>(p => p.IssueTypeId);

            builder.HasOne(p => p.Project)
                   .WithMany(p => p.PreferenceIssueType)
                   .HasForeignKey(p => p.ProjectId);
        }
    }
}