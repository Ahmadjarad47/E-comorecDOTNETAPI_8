using E_commorec.core.Entity;
using E_commorec.core.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commorec.infrastructuer.Data.SeedRoleAndAdmin
{
    public static class SeedingRole
    {

        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                UserManager<AppUsers> userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUsers>>();



                // Seed roles
                string[] rolesToSeed = new[] { Roles.User, Roles.SuperAdmin, Roles.BasicAdmin };
                foreach (var roleName in rolesToSeed)
                {
                    if (!roleManager.RoleExistsAsync(roleName).Result)
                    {
                        IdentityRole role = new IdentityRole { Name = roleName };
                        await roleManager.CreateAsync(role);
                    }
                }

                // Seed a sample user
                AppUsers sampleUser = new AppUsers
                {
                    UserName = "sampleuser@example.com",
                    Email = "sampleuser@example.com",
                    EmailConfirmed = !false,

                    // Add other properties as needed
                };

                if (userManager.FindByEmailAsync(sampleUser.Email).Result == null)
                {
                    IdentityResult result = userManager.CreateAsync(sampleUser, "Your@#.Password123").Result;
                    if (result.Succeeded)
                    {
                        // Assign roles to the sample user
                        await userManager.AddToRoleAsync(sampleUser, Roles.SuperAdmin);
                    }
                }
            }
        }
    }
}
