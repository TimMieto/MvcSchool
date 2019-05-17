using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcSchool.Areas.Identity.Data;
using MvcSchool.Models;
using MvcSchool.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

[assembly: HostingStartup(typeof(MvcSchool.Areas.Identity.IdentityHostingStartup))]
namespace MvcSchool.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SchoolUserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SchoolUserContextConnection")));

                services.AddDefaultIdentity<MvcSchoolUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<SchoolUserContext>();


            });
        }
    }
}