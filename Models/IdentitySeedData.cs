using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SimpleGlossary.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "admin";
        private const string adminPassword = "MySecret123$";
        private const string adminRole = "Admin";

        public static async Task SeedDatabase(IApplicationBuilder app)
        {
            //(GetAppService<IdentityDataContext>(app)).Database.Migrate();
            var context = GetAppService<IdentityDataContext>(app);

            context.Database.Migrate();

            if (context.Database.GetMigrations().Count() > 0
                && context.Database.GetPendingMigrations().Count() == 0)
            {
                UserManager<IdentityUser> userManager
                    = GetAppService<UserManager<IdentityUser>>(app);
                RoleManager<IdentityRole> roleManager
                    = GetAppService<RoleManager<IdentityRole>>(app);

                IdentityRole role = await roleManager.FindByNameAsync(adminRole);
                IdentityUser user = await userManager.FindByNameAsync(adminUser);

                if (role == null)
                {
                    role = new IdentityRole(adminRole);
                    IdentityResult result = await roleManager.CreateAsync(role);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Cannot creat role:" +
                            result.Errors.FirstOrDefault());
                    }
                }

                if (user == null)
                {
                    user = new IdentityUser(adminUser);
                    IdentityResult result
                        = await userManager.CreateAsync(user, adminPassword);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Cannot creat user:" +
                            result.Errors.FirstOrDefault());
                    }
                }

                if (!await userManager.IsInRoleAsync(user, adminRole))
                {
                    IdentityResult result
                        = await userManager.AddToRoleAsync(user, adminRole);
                    if (!result.Succeeded)
                    {
                        throw new Exception("Cannot add user to role:" +
                            result.Errors.FirstOrDefault());
                    }
                }
               }
        }

        private static T GetAppService<T>(IApplicationBuilder app)
        {
            return app.ApplicationServices.GetRequiredService<T>();
        }
    }
}
