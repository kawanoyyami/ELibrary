using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Domain.Models.Auth;
using DataAccess.Seed;

namespace WebAPI.Extensions
{
    public static class HostExtensions
    {
        public static async Task<IHost> SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<Role>>();
                                    
                    await DataSeed.SeedIdentityRoles(roleManager);
                    await DataSeed.SeedIdentityUsers(userManager);
                    await DataSeed.Seed(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
            return host;
        }
    }
}
