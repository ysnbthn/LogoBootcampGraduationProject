using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BootcampProject.DataAccess.EntityFramework.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(i=>i.Id);
            builder.Property(i => i.InvoiceTypeId).IsRequired();
            builder.Property(i => i.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(i => i.PaymentDue).IsRequired();
            builder.Property(i => i.Paid).IsRequired();
            builder.Property(i => i.BillingDate).IsRequired();
        }
    }
}
