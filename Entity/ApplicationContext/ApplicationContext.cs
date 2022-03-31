using Entity.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EFConfiguration;
using System.Reflection;
using Entity.Models;

namespace Entity
{
    public class ApplicationContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Plan>? Plans { get; set; }
        public DbSet<Subscription>? Subscriptions { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Report>? Reports { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var asesmbly = typeof(ApplicationContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(asesmbly);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}
