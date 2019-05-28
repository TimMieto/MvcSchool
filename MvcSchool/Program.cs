using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MvcSchool.Models;
using Microsoft.AspNetCore.Identity;
using MvcSchool.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;

//TestingGit

namespace MvcSchool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var dbContext = services.GetRequiredService<MvcSchoolContext>();
                var userContext = services.GetRequiredService<SchoolUserContext>();
                var userMgr = services.GetRequiredService<UserManager<MvcSchoolUser>>();
                var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();

                var adminRole = new IdentityRole("Admin");

                try
                {
                    dbContext.Database.Migrate();
                    CourseSeed.Initialize(services);

                    userContext.Database.Migrate();
                    if(!userContext.Roles.Any())
                    {
                        roleMgr.CreateAsync(adminRole).GetAwaiter().GetResult();
                    }

                    if(!userContext.Users.Any(u=>u.UserName == "admin"))
                    {
                        var adminUser = new MvcSchoolUser
                        {
                            UserName = "admin@test.com",
                            Email = "admin@test.com"
                        };
                        var result = userMgr.CreateAsync(adminUser, "Password.123").GetAwaiter().GetResult();
                        userMgr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
