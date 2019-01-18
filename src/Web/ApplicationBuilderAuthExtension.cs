namespace BankManagementSystem.Web
{
    using BankManagementSystem.Common.Constants;
    using BankManagementSystem.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderAuthExtension
    {
        private const string DefaultAdminPassword = "admin";
        private const string adminUsername = "admin";
        private const string adminEmail = "admin@email.com";

        private static readonly IdentityRole[] roles =
        {
            new IdentityRole(RolesConstants.Administrator),
            new IdentityRole(RolesConstants.User)
        };

        public static async void SeedDatabaseAsync(
            this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();

            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Client>>();

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }
            }
        }
    }
}
