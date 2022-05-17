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
                        FullName = "Anton Chigurh",
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
                        FullName = "Travis Bickle",
                        UserName = "FreeUser",
                        Email = "freeuser@exemple.com",
                        EmailConfirmed = true,
                        DOB = new DateTime(1947, 5, 11, 0, 0, 0),
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
                        FullName = "Patrick Bateman",
                        UserName = "PaidUser",
                        Email = "paiduser@exemple.com",
                        EmailConfirmed = true,
                        DOB = new DateTime(1961, 1, 21, 0, 0, 0),
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
                    await context.Projects.AddAsync(project);
                }
                {
                    var project = new Project
                    {
                        UserId = 1,
                        Name = "SecondProject",
                    };
                    await context.Projects.AddAsync(project);
                }
                {
                    var project = new Project
                    {
                        UserId = 1,
                        Name = "ThirdProject",
                    };
                    await context.Projects.AddAsync(project);
                }
                {
                    var project = new Project
                    {
                        UserId = 1,
                        Name = "FourthProject",
                    };
                    await context.Projects.AddAsync(project);
                }
                {
                    var project = new Project
                    {
                        UserId = 1,
                        Name = "FifthProject",
                    };
                    await context.Projects.AddAsync(project);
                }
                {
                    var project = new Project
                    {
                        UserId = 1,
                        Name = "SixthProject",
                    };
                    await context.Projects.AddAsync(project);
                }
                {
                    var project = new Project
                    {
                        UserId = 2,
                        Name = "SecondProject",
                    };
                    await context.Projects.AddAsync(project);
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
                    await context.Reports.AddAsync(report);
                }
                {
                    var report = new Report
                    {
                        Name = "SecondReport",
                        Link = "SomeLinkForExempleForSecondProject",
                        ProjectId = 2,
                    };
                    await context.Reports.AddAsync(report);
                }
            }
            if (!context.Books.Any())
            {
                {
                    var book = new Book
                    {
                        Title = "The Lion, the Witch and the Wardrobe",
                        PageCount = 100,
                        ImagePath = "thelion.jpg",
                        Description = "Lewis, The Lion,the Witch and the Wardrobe, the film tells the story of 4 children who go to live with an old professor during the war. One day, while playing hide and seek, Lucy, the youngest of the children, finds a wardrobe which leads to a magical land called Narnia.",
                        AmazonLink = "https://amzn.com/dp/0064404994",
                    };
                    await context.Books.AddAsync(book);

                    var author = new Author
                    {
                        FullName = "Clive Staples Lewis",
                        AreaOfInteresnt = "Novelist",
                        DOB = new DateTime(1963, 11, 22, 0, 0, 0),
                        Books = new List<Book> { book }
                    };
                    await context.Authors.AddAsync(author);

                }
                {
                    var book = new Book
                    {
                        Title = "She: A History of Adventure",
                        PageCount = 100,
                        ImagePath = "she.jpg",
                        Description = "The story is a first-person narrative which follows the journey of Horace Holly and his ward Leo Vincey to a lost kingdom in the African interior. They encounter a primitive race of natives and a mysterious white queen named Ayesha who reigns as the all-powerful She or She - who - must - be - obeyed.",
                        AmazonLink = "https://amzn.com/dp/1925110133",
                    };
                    await context.Books.AddAsync(book);

                    var author = new Author
                    {
                        FullName = "Henry Rider Haggard",
                        AreaOfInteresnt = "Novelist",
                        DOB = new DateTime(1925, 4, 14, 0, 0, 0),
                        Books = new List<Book> { book }
                    };
                    await context.Authors.AddAsync(author);
                }
                {
                    var book = new Book
                    {
                        Title = "The Adventures of Pinocchio",
                        PageCount = 100,
                        ImagePath = "pinocchio.jpg",
                        Description = "Lesson Summary. Carlo Collodi′s The Adventures of Pinocchio is a hugely successful children′s fantasy book. Set in Tuscany, Italy during the late 1800s, it tells the story of a marionette puppet who tries his best to be a good son to his father, Geppetto, so that he can be turned into a real boy by the Blue Fairy",
                        AmazonLink = "https://amzn.com/dp/B0084AMSKI",
                    };
                    await context.Books.AddAsync(book);

                    var author = new Author
                    {
                        FullName = "Carlo Collodi",
                        AreaOfInteresnt = "Writer",
                        DOB = new DateTime(1826, 11, 24, 0, 0, 0),
                        Books = new List<Book> { book }
                    };
                    await context.Authors.AddAsync(author);
                }
                {
                    var book = new Book
                    {
                        Title = "The Da Vinci Code",
                        PageCount = 100,
                        ImagePath = "vincicode.jpg",
                        Description = "The Da Vinci Code follows symbologist Robert Langdon and cryptologist Sophie Neveu after a murder in the Louvre Museum in Paris causes them to become involved in a battle between the Priory of Sion and Opus Dei over the possibility of Jesus Christ and Mary Magdalene having had a child together.",
                        AmazonLink = "https://amzn.com/dp/0307474275",
                    };
                    await context.Books.AddAsync(book);

                    var author = new Author
                    {
                        FullName = "Dan Brown",
                        AreaOfInteresnt = "Writer",
                        DOB = new DateTime(1964, 6, 22, 0, 0, 0),
                        Books = new List<Book> { book }
                    };
                    await context.Authors.AddAsync(author);
                }
                {
                    var book = new Book
                    {
                        Title = "Harry Potter and the Chamber of Secrets",
                        PageCount = 100,
                        ImagePath = "secrets.jpg",
                        Description = "The plot follows Harry's second year at Hogwarts School of Witchcraft and Wizardry, during which a series of messages on the walls of the school's corridors warn that the Chamber of Secrets has been opened and that the heir of Slytherin would kill all pupils who do not come from all-magical families.",
                        AmazonLink = "https://amzn.com/dp/1338716530"
                    };
                    await context.Books.AddAsync(book);

                    var book2 = new Book
                    {
                        Title = "Harry Potter and the Prisoner of Azkaban",
                        PageCount = 100,
                        ImagePath = "azkaban.jpg",
                        Description = "The book follows Harry Potter, a young wizard, in his third year at Hogwarts School of Witchcraft and Wizardry. Along with friends Ronald Weasley and Hermione Granger, Harry investigates Sirius Black, an escaped prisoner from Azkaban, the wizard prison, believed to be one of Lord Voldemort's old allies.",
                        AmazonLink = "https://amzn.com/dp/B017V4NTFA",
                    };
                    await context.Books.AddAsync(book2);


                    var book3 = new Book
                    {
                        Title = "Harry Potter and the Goblet of Fire",
                        PageCount = 100,
                        ImagePath = "goblet.jpg",
                        Description = "Harry Potter finds himself competing in a hazardous tournament between rival schools of magic, but he is distracted by recurring nightmares. Harry Potter finds himself competing in a hazardous tournament between rival schools of magic, but he is distracted by recurring nightmares.",
                        AmazonLink = "https://amzn.com/dp/B017V4NQGM",
                    };
                    await context.Books.AddAsync(book3);


                    var book4 = new Book
                    {
                        Title = "Harry Potter and the Order of the Phoenix",
                        PageCount = 100,
                        ImagePath = "order.jpg",
                        Description = "The Order of the Phoenix was a secret society founded by Albus Dumbledore to oppose Lord Voldemort and his Death Eaters. The original Order was created in the 1970s. It was constructed after Voldemort returned to England from abroad and started his campaign to take over the Ministry of Magic and persecute Muggle-borns.",
                        AmazonLink = "https://amzn.com/dp/B017V4NLJ4",
                    };
                    await context.Books.AddAsync(book4);


                    var book5 = new Book
                    {
                        Title = "Harry Potter and the Half-Blood Prince",
                        PageCount = 100,
                        ImagePath = "half.jpg",
                        Description = "In this book, Harry Potter learns a lot about Lord Voldemort's past, and Harry Potter prepares for the final battle against his nemesis with the help of Headmaster Dumbledore. But in that time, Voldemort returns to power, and makes a plan to destroy Harry.",
                        AmazonLink = "https://amzn.com/dp/B017V4NOEG",
                    };
                    await context.Books.AddAsync(book5);


                    var book6 = new Book
                    {
                        Title = "Harry Potter and the Deathly Hallows",
                        PageCount = 100,
                        ImagePath = "deathly.jpg",
                        Description = "The novel chronicles the events directly following Harry Potter and the Half-Blood Prince (2005) and the final confrontation between the wizards Harry Potter and Lord Voldemort. Deathly Hallows shattered sales records upon release, surpassing marks set by previous titles of the Harry Potter series.",
                        AmazonLink = "https://amzn.com/dp/B017WJ5PR4",
                    };
                    await context.Books.AddAsync(book6);

                    var author = new Author
                    {
                        FullName = "Joanne Rowling",
                        AreaOfInteresnt = "Writer",
                        DOB = new DateTime(1965, 7, 31, 0, 0, 0),
                        Books = new List<Book> { book, book2, book3, book4, book5, book6 }
                    };
                    await context.Authors.AddAsync(author);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
