using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.IssueCustomfieldDataSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.IssueCustomfieldDataSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class IssueCustomfieldDataConfiguration : IEntityTypeConfiguration<IssueCustomfieldData>
    {
        public void Configure(EntityTypeBuilder<IssueCustomfieldData> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Value).HasColumnName(fields.Value).IsRequired();
            builder.Property(p => p.CustomfieldId).HasColumnName(fields.CustomfieldId).IsRequired();
            builder.Property(p => p.IssueId).HasColumnName(fields.IssueId).IsRequired();

            builder.HasOne(p => p.Customfield)
                   .WithMany(p => p.CustomfieldsData)
                   .HasForeignKey(p => p.CustomfieldId);

            builder.HasOne(p => p.Issue)
                   .WithMany(p => p.CustomfieldsData)
                   .HasForeignKey(p => p.IssueId);
        }
    }
}