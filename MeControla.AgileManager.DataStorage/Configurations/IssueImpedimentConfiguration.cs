using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.IssueImpedimentSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.IssueImpedimentSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class IssueImpedimentConfiguration : IEntityTypeConfiguration<IssueImpediment>
    {
        public void Configure(EntityTypeBuilder<IssueImpediment> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Start).HasColumnName(fields.Start).IsRequired();
            builder.Property(p => p.End).HasColumnName(fields.End);
            builder.Property(p => p.IssueId).HasColumnName(fields.IssueId).IsRequired();

            builder.HasOne(p => p.Issue)
                   .WithMany(p => p.Impediments)
                   .HasForeignKey(p => p.IssueId)
                   .IsRequired();
        }
    }
}