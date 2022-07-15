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
            builder.Property(p => p.Quarter);

            builder.HasOne(p => p.Issue)
                   .WithOne(p => p.IssueEpic)
                   .HasForeignKey<IssueEpic>(e => e.IssueId);

            builder.HasIndex(p => p.IssueId)
                   .IsUnique();
        }
    }
}