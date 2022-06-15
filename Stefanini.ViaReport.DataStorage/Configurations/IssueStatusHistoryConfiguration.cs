using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.ViaReport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.DataStorage.Configurations
{
    internal class IssueStatusHistoryConfiguration : IEntityTypeConfiguration<IssueStatusHistory>
    {
        public void Configure(EntityTypeBuilder<IssueStatusHistory> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.DateTime).IsRequired();

            builder.HasOne(p => p.Issue)
                   .WithMany(p => p.Statuses)
                   .HasForeignKey(p => p.IssueId)
                   .IsRequired();

            builder.HasOne(p => p.Status)
                   .WithMany()
                   .HasForeignKey(p => p.StatusId)
                   .IsRequired();
        }
    }
}