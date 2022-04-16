using BootcampProject.DataAccess.EntityFramework.Enums;
using BootcampProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampProject.DataAccess.EntityFramework.Seed
{
    public class ContextSeed
    {
        public static async Task SeedRoleAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var admin = new ApplicationUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                Name = "Yasin Batuhan",
                Surname = "Özyürek",
                TCNo = "12345678901",
                PhoneNumber = "05555555555",
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != admin.Id))
            {
                var user = await userManager.FindByEmailAsync(admin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(admin, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(admin, Roles.Basic.ToString());
                }
            }
        }

        public static async Task SeedBasicAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var basic = new ApplicationUser
            {
                UserName = "yasinbatuhanozyurek@gmail.com",
                Email = "yasinbatuhanozyurek@gmail.com",
                Name = "Yasin Batuhan",
                Surname = "Özyürek",
                TCNo = "12345678902",
                PhoneNumber = "05395555555",
                CreatedAt = DateTime.Now,
                IsDeleted = false,
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != basic.Id))
            {
                var user = await userManager.FindByEmailAsync(basic.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(basic, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                }
            }
        }

    }
}
