using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BootcampProject.DataAccess.EntityFramework.Configurations
{
    public class BlockConfiguration : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder.ToTable("Blocks");
            builder.HasKey("Id");
            builder.Property(b => b.Name).HasMaxLength(3).IsRequired();

            builder.HasData(
                new Block { Id = Guid.NewGuid(), Name = "A", CreatedAt = DateTime.Now },
                new Block { Id = Guid.NewGuid(), Name = "B", CreatedAt = DateTime.Now },
                new Block { Id = Guid.NewGuid(), Name = "A1", CreatedAt = DateTime.Now }
                );
        }
    }
}
