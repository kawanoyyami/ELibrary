using Entity.Models.Auth;
using Entity.Repository;
using WebAPI.Services;
using WebAPI.Services.Interfaces;
using Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Model.Auth;

namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Service
            services.AddScoped<IBookSevice, BookService>();
            services.AddScoped<IPaymentService,PaymentService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorSevice, AuthorService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IReportSevice, ReportSevice>();


            return services;
        }
    }
}
