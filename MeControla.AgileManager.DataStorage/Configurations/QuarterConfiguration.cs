using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.QuarterSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.QuarterSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class QuarterConfiguration : IEntityTypeConfiguration<Quarter>
    {
        public void Configure(EntityTypeBuilder<Quarter> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(p => p.Epics)
                   .WithOne(p => p.Quarter)
                   .HasForeignKey(p => p.QuarterId);
        }
    }
}