using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Indo_Burma.Models
{
    public static class IdentitySeedData
    {
        //Seed the dataset with the admin username and password
        private const string adminUser = "Admin";
        private const string adminPassword = "413ExtraYeetPeriod(t)!";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();

            //If there is anything to work with migrate it.
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            // If there isn't already a user.. than seed this data
            if (user == null)
            {
                user = new IdentityUser(adminUser);
                user.Email = "ryan@rrevelyn.com";
                user.PhoneNumber = "385-439-3033";

                await userManager.CreateAsync(user, adminPassword);
            }

        }
    }
}
