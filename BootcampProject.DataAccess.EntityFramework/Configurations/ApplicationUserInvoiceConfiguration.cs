using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.DataAccess.EntityFramework.Configurations
{
    public class ApplicationUserInvoiceConfiguration : IEntityTypeConfiguration<ApplicationUserInvoice>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserInvoice> builder)
        {
            builder
                .ToTable("ApplicationUserInvoices");
            builder
                .HasKey(api => new { api.UserId, api.InvoiceId });
            builder
                .HasOne(x => x.Invoice)
                .WithMany(xd => xd.ApplicationUserInvoices)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.ApplicationUser)
                .WithMany(xd => xd.ApplicationUserInvoices)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
