﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Entity;
using Microsoft.EntityFrameworkCore;
using Entity.Repository;
using Entity.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Entity.Repository.Interfaces;
using WebAPI.Services;
using WebAPI.Services.Interfaces;
using System.Reflection;
using WebAPI.Model.Auth;
using WebAPI.Middlewares;
using MediatR;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ELibrary.Web.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });

            //Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Service
            services.AddScoped<IBookSevice, BookService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorSevice, AuthorService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IReportSevice, ReportSevice>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddCors();

            //Identity 
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.";
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddEntityFrameworkStores<ApplicationContext>();

            // Auth
            var authOptionsConfiguration = Configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authOptionsConfiguration);
            var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToAccessDenied =
                    options.Events.OnRedirectToLogin = context =>
                    {
                        if (context.Request.Method != "GET")
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.FromResult<object>(null);
                        }
                        context.Response.Redirect(context.RedirectUri);
                        return Task.FromResult<object>(null);
                    };
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidIssuer = authOptions.Issuer,

                     ValidateAudience = true,
                     ValidAudience = authOptions.Audience,

                     ValidateLifetime = true,
                     ValidateActor = true,

                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = authOptions.GetSymmetricSecurityKey()
                 };
             });

            services.AddAuthorization();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/App-{Date}.txt");

            if (env.IsDevelopment())
            {
                //app.UseErrorHandling(); @TO-DO uncoment this 
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                    c.OAuthClientId(Configuration["Authentication:ClientId"]);
                });
            }
            app.UseErrorHandling();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
