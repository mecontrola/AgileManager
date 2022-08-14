using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.IssueSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.IssueSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Key).HasColumnName(fields.Key).IsRequired();
            builder.Property(p => p.Summary).HasColumnName(fields.Summary).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Incident).HasColumnName(fields.Incident).HasDefaultValue(false);
            builder.Property(p => p.Created).HasColumnName(fields.Created).IsRequired();
            builder.Property(p => p.Updated).HasColumnName(fields.Updated).IsRequired();
            builder.Property(p => p.Resolved).HasColumnName(fields.Resolved);
            builder.Property(p => p.Link).HasColumnName(fields.Link).IsRequired();
            builder.Property(p => p.ProjectId).HasColumnName(fields.ProjectId).IsRequired();
            builder.Property(p => p.IssueTypeId).HasColumnName(fields.IssueTypeId).IsRequired();
            builder.Property(p => p.StatusId).HasColumnName(fields.StatusId).IsRequired();

            builder.Property(p => p.CustomField14503).HasColumnName(fields.CustomField14503);

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

            //builder.HasMany(p => p.CustomfieldData)
            //       .WithOne(p => p.Issue)
            //       .HasForeignKey(p => p.IssueId)
            //       .IsRequired();

            builder.HasOne(p => p.IssueEpic)
                   .WithOne(p => p.Issue)
                   .HasForeignKey<IssueEpic>(p => p.IssueId);
        }
    }
}