using Microsoft.AspNetCore.Identity;
using ToDoList.Models;

namespace ToDoList.Util;

public class AdminInitializer
{
    public static async Task SeedAdminAsync(
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        const string adminEmail = "admin@admin.com";
        const string adminPassword = "password";

        var roles = new[] { "user", "admin" };
        foreach (var role in roles)
        {
            if (await roleManager.FindByNameAsync(role) is null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        if (await userManager.FindByEmailAsync(adminEmail) is null)
        {
            var user = new User {
                Email = adminEmail, 
                UserName = adminEmail,
            };
            var result = await userManager.CreateAsync(user, adminPassword);
            if (result.Succeeded) 
                await userManager.AddToRoleAsync(user, "admin");
        }
    }
}