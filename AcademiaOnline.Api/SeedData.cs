using AcademiaOnline.Domain.Entities;
using AcademiaOnline.Infrastructure.Persistence.Data.Identity;
using Microsoft.AspNetCore.Identity;

namespace AcademiaOnline.Api
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<TbUsuario>>();
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

            const string adminRole = "Admin";
            const string adminEmail = "admin@academico.com";
            const string adminPassword = "px30$jioA123!";

            if (!await roleManager.RoleExistsAsync(adminRole))
                await roleManager.CreateAsync(new ApplicationRole { Name = adminRole });

            var user = await userManager.FindByEmailAsync(adminEmail);
            if (user == null)
            {
                user = new TbUsuario { NombreCompleto = "Faber Orozco", UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, adminRole);
            }
        }
    }

}
