﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class FileOnDatabaseModelConfiguration : IEntityTypeConfiguration<FileOnDatabaseModel>
    {
        public void Configure(EntityTypeBuilder<FileOnDatabaseModel> builder)
        {
            builder.ToTable("FilesOnDatabase").HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FileType).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Extension).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.UploadedBy).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.CreatedOn).IsRequired(false);
            builder.Property(x => x.Data).IsRequired();

            

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
