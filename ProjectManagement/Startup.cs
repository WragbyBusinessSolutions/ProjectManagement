using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity.UI.Services;
using ProjectManagement.Helpers;
using ProjectManagement.Services;
using ProjectManagement.MailServices;
using ProjectManagement.Extensions;
using ProjectManagement.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace ProjectManagement
{
    public class Startup
    {
        public const string ObjectIdentifierType = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        public const string TenantIdType = "http://schemas.microsoft.com/identity/claims/tenantid";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>(options => { options.Stores.MaxLengthForKeys = 128; })
           .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);


            services.AddAuthentication(options =>
            {
                options.DefaultScheme = OpenIdConnectDefaults.AuthenticationScheme;
               
            })
                .AddAzureAd(options => Configuration.Bind("AzureAd", options))
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.SlidingExpiration = true;


                }).
                  Services.AddSession(
                             options => options.IdleTimeout = TimeSpan.FromMinutes(30)
                   );


            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });



            services.AddAuthorization(options =>
            {
                

                options.AddPolicy("Admin", policy =>

                {
                   
                    policy.RequireClaim("groups", Configuration.GetValue<string>("AzureSecurityGroup:AdminId"));

                });




                options.AddPolicy("PM", policyBuilder =>

                {
                    policyBuilder.RequireClaim("groups", Configuration.GetValue<string>("AzureSecurityGroup:PMId"));


                });


                options.AddPolicy("Manager", policyBuilder =>
                {
                    policyBuilder.RequireClaim("groups", Configuration.GetValue<string>("AzureSecurityGroup:ManagerId"));

                });



                options.AddPolicy("AssDir", policyBuilder =>

                {
                    policyBuilder.RequireClaim("groups", Configuration.GetValue<string>("AzureSecurityGroup:AssDirId"));

                });


                options.AddPolicy("DepDir", policyBuilder =>
                {
                    policyBuilder.RequireClaim("groups", Configuration.GetValue<string>("AzureSecurityGroup:DepDirID"));

                });
            });





            services.AddTransient<MailServices.IEmailSender, EmailSender>();
            services.AddSingleton<IGraphAuthProvider, GraphAuthProvider>();
            services.AddTransient<IGraphSdkHelper, GraphSdkHelper>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
