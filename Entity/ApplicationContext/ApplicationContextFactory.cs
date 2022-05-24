using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccess
{
    internal class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public static ApplicationContext CreateApplicationContext(string connectionType)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            string connectionString = configuration.GetConnectionString(connectionType);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            return new ApplicationContext(options);
        }
        public ApplicationContext CreateDbContext(string[] args)
        {
            return CreateApplicationContext("DefaultConnection");
        }
    }
}
