using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.DataStorage.Configurations
{
    internal class QuarterConfiguration : IEntityTypeConfiguration<Quarter>
    {
        public void Configure(EntityTypeBuilder<Quarter> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(p => p.Epics)
                   .WithOne(p => p.Quarter)
                   .HasForeignKey(p => p.QuarterId);
        }
    }
}