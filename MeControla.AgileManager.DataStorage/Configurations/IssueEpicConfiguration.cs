using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.IssueEpicSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.IssueEpicSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class IssueEpicConfiguration : IEntityTypeConfiguration<IssueEpic>
    {
        public void Configure(EntityTypeBuilder<IssueEpic> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Progress).HasColumnName(fields.Progress).IsRequired();
            builder.Property(p => p.IssueId).HasColumnName(fields.IssueId).IsRequired();
            builder.Property(p => p.QuarterId).HasColumnName(fields.QuarterId);

            builder.HasOne(p => p.Issue)
                   .WithOne(p => p.IssueEpic)
                   .HasForeignKey<IssueEpic>(e => e.IssueId);

            builder.HasOne(p => p.Quarter)
                   .WithMany(p => p.Epics)
                   .HasForeignKey(p => p.QuarterId);

            builder.HasIndex(p => p.IssueId)
                   .IsUnique();
        }
    }
}