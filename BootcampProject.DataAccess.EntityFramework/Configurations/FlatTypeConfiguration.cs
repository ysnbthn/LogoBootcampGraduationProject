using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BootcampProject.DataAccess.EntityFramework.Configurations
{
    public class FlatTypeConfiguration : IEntityTypeConfiguration<FlatType>
    {
        public void Configure(EntityTypeBuilder<FlatType> builder)
        {
            builder.ToTable("FlatTypes");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Name).IsRequired().HasMaxLength(5);

            builder.HasData(
                new FlatType { Id = 1, Name = "1+1", CreatedAt = DateTime.Now }, 
                new FlatType { Id = 2, Name = "2+1", CreatedAt = DateTime.Now }, 
                new FlatType { Id = 3, Name = "3+1", CreatedAt = DateTime.Now }, 
                new FlatType { Id = 4, Name = "4+2", CreatedAt = DateTime.Now } 
                );
        }
    }
}
