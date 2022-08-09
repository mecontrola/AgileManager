using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.IssueStatusHistorySchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.IssueStatusHistorySchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class IssueStatusHistoryConfiguration : IEntityTypeConfiguration<IssueStatusHistory>
    {
        public void Configure(EntityTypeBuilder<IssueStatusHistory> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.DateTime).HasColumnName(fields.DateTime).IsRequired();
            builder.Property(p => p.IssueId).HasColumnName(fields.IssueId).IsRequired();
            builder.Property(p => p.StatusId).HasColumnName(fields.StatusId).IsRequired();

            builder.HasOne(p => p.Issue)
                   .WithMany(p => p.Statuses)
                   .HasForeignKey(p => p.IssueId)
                   .IsRequired();

            builder.HasOne(p => p.Status)
                   .WithMany()
                   .HasForeignKey(p => p.StatusId)
                   .IsRequired();
        }
    }
}