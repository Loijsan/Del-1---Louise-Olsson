using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Del_1___Louise_Olsson.Data
{
    public static class DbInitializer
    {

        public static async Task Initialize(RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager)
        {
            // OOO This part creates the different roles if they don't exist
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var adminRole = await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
            }


            // OOO This part creates the admin if no one with that email exists and gives it the right role
            var admin = new IdentityUser
            {
                UserName = "super@admin.nu",
                Email = "super@admin.nu",
                PhoneNumber = "0708080808",
                EmailConfirmed = true
            };
            var adminResult = await _userManager.FindByEmailAsync(admin.Email);
            if (adminResult is null)
            {
                await _userManager.CreateAsync(admin, "Minst 15 tecken långt");
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            // OOO This part creates a user if no one with that email exists and gives it the right role
            var user = new IdentityUser
            {
                UserName = "user@user.nu",
                Email = "user@user.nu",
                PhoneNumber = "0707070707",
                EmailConfirmed = true
            };

            var userResult = await _userManager.FindByEmailAsync(user.Email);
            if (userResult is null)
            {
                await _userManager.CreateAsync(user, "Också 15 tecken långt");
                await _userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
