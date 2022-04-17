using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootcampProject.DataAccess.EntityFramework.Configurations
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartments");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Floor).IsRequired();
            builder.Property(a => a.ApartmentNumber).IsRequired();
            builder.Property(a => a.ApplicationUserId).IsRequired();
            builder.Property(a => a.FlatTypeId).IsRequired();
            builder.Property(a => a.BlockId).IsRequired();
        }
    }
}
