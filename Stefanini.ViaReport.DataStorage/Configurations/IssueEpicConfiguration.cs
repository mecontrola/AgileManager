using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.DataStorage.Configurations
{
    internal class IssueEpicConfiguration : IEntityTypeConfiguration<IssueEpic>
    {
        public void Configure(EntityTypeBuilder<IssueEpic> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Progress).IsRequired();

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