using BootcampProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootcampProject.DataAccess.EntityFramework.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");
            builder.Property(u=>u.Name).IsRequired().HasMaxLength(20);
            builder.Property(u=>u.Surname).IsRequired().HasMaxLength(20);
            builder.Property(u => u.TCNo).IsRequired().HasMaxLength(11).IsFixedLength(true);
            builder.Property(u => u.CarPlateNumber).HasMaxLength(8);
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(11).IsFixedLength(true);
        }
    }
}
