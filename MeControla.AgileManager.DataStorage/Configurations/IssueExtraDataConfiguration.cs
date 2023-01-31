using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.IssueExtraDataSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.IssueExtraDataSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class IssueExtraDataConfiguration : IEntityTypeConfiguration<IssueExtraData>
    {
        public void Configure(EntityTypeBuilder<IssueExtraData> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id);
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.StoryPoints).HasColumnName(fields.StoryPoints);
            builder.Property(p => p.Impediment).HasColumnName(fields.Impediment);
            builder.Property(p => p.CustomerLeadTime).HasColumnName(fields.CustomerLeadTime);
            builder.Property(p => p.DiscoveryLeadTime).HasColumnName(fields.DiscoveryLeadTime);
            builder.Property(p => p.SystemLeadTime).HasColumnName(fields.SystemLeadTime);
            builder.Property(p => p.ClassOfServiceId).HasColumnName(fields.ClassOfServiceId);

            builder.HasOne(p => p.Issue)
                   .WithOne(p => p.ExtraData)
                   .HasForeignKey<IssueExtraData>(e => e.Id);

            builder.HasOne(p => p.ClassOfService)
                   .WithMany(p => p.IssueExtraDatas)
                   .HasForeignKey(p => p.ClassOfServiceId);

            builder.HasIndex(p => p.Id)
                   .IsUnique();
        }
    }
}