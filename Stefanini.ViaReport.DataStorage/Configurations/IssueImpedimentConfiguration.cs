using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.DataStorage.Configurations
{
    internal class IssueImpedimentConfiguration : IEntityTypeConfiguration<IssueImpediment>
    {
        public void Configure(EntityTypeBuilder<IssueImpediment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Start).IsRequired();
            builder.Property(p => p.End);

            builder.HasOne(p => p.Issue)
                   .WithMany(p => p.Impediments)
                   .HasForeignKey(p => p.IssueId)
                   .IsRequired();
        }
    }
}