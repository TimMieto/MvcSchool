using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MvcSchool.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;

namespace MvcSchool
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //一致
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.Configure<IISOptions>(options =>
            //{
            //    options.ForwardClientCertificate = false;
            //});

            //services.AddDbContext<SchoolUserContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));


            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    //.AddDefaultUI(UIFramework.Bootstrap4)
            //    .AddEntityFrameworkStores<SchoolUserContext>()
            //    .AddDefaultTokenProviders();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            //    .AddRazorPagesOptions(options =>
            //    {
            //        options.AllowAreas = true;
            //        options.Conventions.AuthorizeAreaFolder("Identity", "/Pages/Account/Manage");
            //        options.Conventions.AuthorizeAreaPage("Identity", "/Pages/Account/Logout");
            //    });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = $"/Identity/Pages/Account/Login";
            //    options.LogoutPath = $"/Identity/Pages/Account/Logout";
            //    options.AccessDeniedPath = $"/Identity/Pages/Account/AccessDenied";
            //});

            //这一行是基架添加的
            services.AddDbContext<MvcSchoolContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MvcSchoolContext")));
            //services.AddDbContext<SchoolUserContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
            //     .AddEntityFrameworkStores<MvcSchoolContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
