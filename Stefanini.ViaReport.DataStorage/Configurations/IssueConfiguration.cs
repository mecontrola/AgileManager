using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.DataStorage.Configurations
{
    internal class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Key).IsRequired();
            builder.Property(p => p.Summary).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Incident).HasDefaultValue(false);
            builder.Property(p => p.Created).IsRequired();
            builder.Property(p => p.Updated).IsRequired();
            builder.Property(p => p.Resolved);
            builder.Property(p => p.Link).IsRequired();
            builder.Property(p => p.CustomField14503);

            builder.HasOne(p => p.Project)
                   .WithMany(p => p.Issues)
                   .HasForeignKey(p => p.ProjectId)
                   .IsRequired();

            builder.HasOne(p => p.Status)
                   .WithMany(p => p.Issues)
                   .HasForeignKey(p => p.StatusId)
                   .IsRequired();

            builder.HasOne(p => p.IssueType)
                   .WithMany(p => p.Issues)
                   .HasForeignKey(p => p.IssueTypeId)
                   .IsRequired();

            builder.HasOne(p => p.IssueEpic)
                   .WithOne(p => p.Issue)
                   .HasForeignKey<IssueEpic>(p => p.IssueId);
        }
    }
}