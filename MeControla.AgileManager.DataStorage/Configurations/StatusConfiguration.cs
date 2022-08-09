using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.StatusSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.StatusSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Key).HasColumnName(fields.Key).IsRequired();
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.StatusCategoryId).HasColumnName(fields.StatusCategoryId).IsRequired();

            builder.HasOne(p => p.StatusCategory)
                   .WithMany(p => p.Statuses)
                   .HasForeignKey(p => p.StatusCategoryId)
                   .IsRequired();
        }
    }
}