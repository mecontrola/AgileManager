using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.StatusCategorySchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.StatusCategorySchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class StatusCategoryConfiguration : IEntityTypeConfiguration<StatusCategory>
    {
        public void Configure(EntityTypeBuilder<StatusCategory> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Key).HasColumnName(fields.Key).IsRequired();
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(p => p.Statuses)
                   .WithOne(p => p.StatusCategory)
                   .HasForeignKey(p => p.StatusCategoryId);
        }
    }
}