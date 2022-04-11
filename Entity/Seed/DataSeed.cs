using Entity.Models;
using Entity.Models.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Seed
{
    public class DataSeed
    {
        public static async Task SeedIdentityRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new Role() { Name = "FreeUser" });
                await roleManager.CreateAsync(new Role() { Name = "PaidUser" });
                await roleManager.CreateAsync(new Role() { Name = "admin" });
            }
        }
        public static async Task SeedIdentityUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                {
                    var user = new User
                    {
                        FullName = "Vlados",
                        UserName = "admin",
                        Email = "admin@exemple.com",
                        EmailConfirmed = true,
                    };


                    var result = await userManager.CreateAsync(user, "123admin123");
                    if (result.Succeeded)
                    {
                        await userManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));
                        await userManager.AddClaimAsync(user, new Claim("userName", user.UserName));
                        await userManager.AddClaimAsync(user, new Claim("email", user.Email));
                        await userManager.AddToRoleAsync(user, "admin");
                    }
                }
                {
                    var user = new User
                    {
                        FullName = "Dimas",
                        UserName = "FreeUser",
                        Email = "freeuser@exemple.com",
                        EmailConfirmed = true,
                    };

                    var result = await userManager.CreateAsync(user, "freeuser123");
                    if (result.Succeeded)
                    {
                        await userManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));
                        await userManager.AddClaimAsync(user, new Claim("userName", user.UserName));
                        await userManager.AddClaimAsync(user, new Claim("email", user.Email));
                        await userManager.AddToRoleAsync(user, "FreeUser");
                    }
                }
                {
                    var user = new User
                    {
                        FullName = "Felix",
                        UserName = "PaidUser",
                        Email = "paiduser@exemple.com",
                        EmailConfirmed = true,
                    };

                    var result = await userManager.CreateAsync(user, "paiduser123");
                    if (result.Succeeded)
                    {
                        await userManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));
                        await userManager.AddClaimAsync(user, new Claim("userName", user.UserName));
                        await userManager.AddClaimAsync(user, new Claim("email", user.Email));
                        await userManager.AddToRoleAsync(user, "PaidUser");
                    }
                }
            }
        }
        public static async Task Seed(ApplicationContext context)
        {
            if (!context.Projects.Any())
            {
                {
                    var project = new Project
                    {
                        UserId = 1,
                        Name = "FirstProject",
                    };
                    context.Projects.Add(project);
                }
                {
                    var project = new Project
                    {
                        UserId = 2,
                        Name = "SecondProject",
                    };
                    context.Projects.Add(project);
                }
            }
            if (!context.Reports.Any())
            {
                {
                    var report = new Report
                    {
                        Name = "FirstReport",
                        Link = "SomeLinkForExempleForFirstProject",
                        ProjectId = 1,
                    };
                    context.Reports.Add(report);
                }
                {
                    var report = new Report
                    {
                        Name = "SecondReport",
                        Link = "SomeLinkForExempleForSecondProject",
                        ProjectId = 2,
                    };
                    context.Reports.Add(report);
                }
            }
            if (!context.Books.Any())
            {
                {
                    var book = new Book
                    {
                        Title = "The Lion, the Witch and the Wardrobe",
                        PageCount = 100,
                    };
                    context.Books.Add(book);
                }
                {
                    var book = new Book
                    {
                        Title = "She: A History of Adventure",
                        PageCount = 100,
                    };
                    context.Books.Add(book);
                }{
                    var book = new Book
                    {
                        Title = "The Adventures of Pinocchio",
                        PageCount = 100,
                    };
                    context.Books.Add(book);
                }{
                    var book = new Book
                    {
                        Title = "The Da Vinci Code",
                        PageCount = 100,
                    };
                    context.Books.Add(book);
                }{
                    var book = new Book
                    {
                        Title = "Harry Potter and the Chamber of Secrets",
                        PageCount = 100,
                    };
                    context.Books.Add(book);
                }{
                    var book = new Book
                    {
                        Title = "Harry Potter and the Prisoner of Azkaban",
                        PageCount = 100,
                    };
                    context.Books.Add(book);
                }{
                    var book = new Book
                    {
                        Title = "Harry Potter and the Goblet of Fire",
                        PageCount = 100,
                    };
                    context.Books.Add(book);
                }{
                    var book = new Book
                    {
                        Title = "Harry Potter and the Order of the Phoenix",
                        PageCount = 100,
                    };
                    context.Books.Add(book);
                }{
                    var book = new Book
                    {
                        Title = "Harry Potter and the Half-Blood Prince",
                        PageCount = 100,
                    };
                    context.Books.Add(book);
                }{
                    var book = new Book
                    {
                        Title = "Harry Potter and the Deathly Hallows",
                        PageCount = 100,
                    };
                    context.Books.Add(book);
                }
            }
            if(!context.Authors.Any())
            {
                {
                    var author = new Author
                    {
                        FullName = "Clive Staples Lewis",
                        AreaOfInteresnt = "Novelist",
                        DOB = new DateTime(1963,11,22,0,0,0),
                    };
                    context.Authors.Add(author);
                }
                {
                    var author = new Author
                    {
                        FullName = "Henry Rider Haggard",
                        AreaOfInteresnt = "Novelist",
                        DOB = new DateTime(1925,4,14,0,0,0),
                    };
                    context.Authors.Add(author);
                }
                {
                    var author = new Author
                    {
                        FullName = "Carlo Collodi",
                        AreaOfInteresnt = "Writer",
                        DOB = new DateTime(1826,11,24,0,0,0),
                    };
                    context.Authors.Add(author);
                }{
                    var author = new Author
                    {
                        FullName = "Dan Brown",
                        AreaOfInteresnt = "Writer",
                        DOB = new DateTime(1964,6,22,0,0,0),
                    };
                    context.Authors.Add(author);
                }{
                    var author = new Author
                    {
                        FullName = "Joanne Rowling",
                        AreaOfInteresnt = "Writer",
                        DOB = new DateTime(1965, 7, 31, 0,0,0),
                    };
                    context.Authors.Add(author);
                }
            }
            await context.SaveChangesAsync();
        }
    }
}
