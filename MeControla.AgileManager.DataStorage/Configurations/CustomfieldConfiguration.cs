﻿using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using definition = MeControla.AgileManager.DataStorage.Schemas.CustomFieldSchema;
using fields = MeControla.AgileManager.DataStorage.Schemas.CustomFieldSchema.Columns;

namespace MeControla.AgileManager.DataStorage.Configurations
{
    internal class CustomfieldConfiguration : IEntityTypeConfiguration<CustomField>
    {
        public void Configure(EntityTypeBuilder<CustomField> builder)
        {
            builder.ToTable(definition.Table, definition.Schema);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName(fields.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName(fields.Uuid).IsRequired().HasMaxLength(36);
            builder.Property(p => p.Key).HasColumnName(fields.Key).IsRequired();
            builder.Property(p => p.Name).HasColumnName(fields.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Type).HasColumnName(fields.Type).IsRequired().HasMaxLength(80);
            builder.Property(p => p.Custom).HasColumnName(fields.Custom).IsRequired().HasMaxLength(150);

            builder.HasOne(p => p.Preference)
                   .WithOne(p => p.CustomField)
                   .HasForeignKey<PreferenceCustomField>(p => p.CustomFieldId);
        }
    }
}