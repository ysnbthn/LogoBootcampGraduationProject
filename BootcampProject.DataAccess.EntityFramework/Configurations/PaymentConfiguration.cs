using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootcampProject.DataAccess.EntityFramework.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BillingDate).IsRequired();
            builder.Property(p => p.PaymentDue).IsRequired();
            builder.Property(p => p.IsPaid).IsRequired();
            builder.Property(p => p.PaymentType).IsRequired();
            builder.Property(p => p.Amount).HasMaxLength(20).IsRequired();
            builder.Property(p => p.UserName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.UserEmail).HasMaxLength(50).IsRequired();
            builder.Property(p => p.UserPhone).HasMaxLength(11).IsRequired();
        }
    }
}
