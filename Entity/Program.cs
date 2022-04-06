using Entity.Models.Auth;
using Microsoft.AspNetCore.Identity;
using System;

namespace Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = ApplicationContextFactory.CreateApplicationContext("DefaultConnection"))
            {
                if (db.Database.CanConnect())
                {
                    Console.WriteLine("Connection with Database - success!");
                }
            }
            Console.Read();
        }
        public static async Task SeedIdentityRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role { Id = 1, Name = "user" });
                await roleManager.CreateAsync(new Role { Id = 2, Name = "vendor" });
                await roleManager.CreateAsync(new Role { Id = 3, Name = "operator" });
                await roleManager.CreateAsync(new Role { Id = 4, Name = "admin" });
            }
        }
    }
}