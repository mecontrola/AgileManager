using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.DeploySchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.DeploySchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class DeployConfiguration : IEntityTypeConfiguration<Deploy>
    {
        public void Configure(EntityTypeBuilder<Deploy> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Services).HasColumnName(fields.Services).IsRequired().HasMaxLength(150);
            builder.Property(p => p.DeployedIn).HasColumnName(fields.DeployedIn);

            builder.HasOne(p => p.Issue)
                   .WithOne(p => p.Deploy)
                   .HasForeignKey<Deploy>(p => p.IssueId);
        }
    }
}
