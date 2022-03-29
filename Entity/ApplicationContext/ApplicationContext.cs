using Entity.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.Reports;
using Entity.Models.Books;
using Entity.Models.Subscription;
using Entity.EFConfiguration;

namespace Entity
{
    internal class ApplicationContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration<Book>(new BookConfiguration());
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfiguration());
            modelBuilder.ApplyConfiguration<Project>(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration<Subscription>(new SubscriptionConfiguration());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

    }
}
