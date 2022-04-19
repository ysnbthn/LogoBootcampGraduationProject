using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BootcampProject.DataAccess.EntityFramework.Configurations
{
    public class InvoiceTypeConfiguration : IEntityTypeConfiguration<InvoiceType>
    {
        public void Configure(EntityTypeBuilder<InvoiceType> builder)
        {
            builder
                .ToTable("InvoiceType");
            builder
                .HasKey(it => it.Id);
            builder
                .Property(it => it.Name)
                .IsRequired()
                .HasMaxLength(20);
            
            builder.HasData(
                new InvoiceType { Id = 1, Name = "Electric Bill", CreatedAt = DateTime.Now },
                new InvoiceType { Id = 2, Name = "Gas Bill", CreatedAt = DateTime.Now },
                new InvoiceType { Id = 3, Name = "Water Bill", CreatedAt = DateTime.Now },
                new InvoiceType { Id = 4, Name = "Dues", CreatedAt = DateTime.Now }
                );
        }
    }
}
