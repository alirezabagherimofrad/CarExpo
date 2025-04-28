using CarExpo.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Seeders
{
    public static class IdentitySeeder
    {
        public static async Task SeedRolesAndAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            // تعریف رول‌های اصلی
            string[] roleNames = { "Admin", "Seller", "Buyer", "SiteManager" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
                }
            }

            // ساخت کاربر مدیر سایت
            string siteManagerEmail = "hbi1381819@gmail.com";
            string siteManagerPhoneNumber = "09216851355";  
            string siteManagerNationalCode = "0025227955";
            string siteManagerPassword = "@Amirali7881";

            var existingUser = await userManager.FindByEmailAsync(siteManagerEmail);
            if (existingUser == null)
            {
                var user = new User
                {
                    Id = Guid.NewGuid(), 
                    UserName = siteManagerEmail,
                    Email = siteManagerEmail,
                    PhoneNumber = siteManagerPhoneNumber,
                    NationalCode = siteManagerNationalCode, 
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                var createResult = await userManager.CreateAsync(user, siteManagerPassword);
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "SiteManager");
                }
                else
                {
                    throw new Exception("خطا در ایجاد مدیر سایت: " + string.Join(", ", createResult.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
