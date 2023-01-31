using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.PeriodSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.PeriodSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class PeriodConfiguration : IEntityTypeConfiguration<Period>
    {
        public void Configure(EntityTypeBuilder<Period> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Key).HasColumnName(fields.Key).IsRequired();
            builder.Property(p => p.Type).HasColumnName(fields.Type).IsRequired();
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Initial).HasColumnName(fields.Initial).IsRequired();
            builder.Property(p => p.Final).HasColumnName(fields.Final);
            builder.Property(p => p.ProjectId).HasColumnName(fields.ProjectId).IsRequired();
        }
    }
}