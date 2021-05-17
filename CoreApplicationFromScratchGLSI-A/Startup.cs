using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using CoreApplicationFromScratchGLSI_A.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using CoreApplicationFromScratchGLSI_A.Areas.Admin.Services;
using CoreApplicationFromScratchGLSI_A.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CoreApplicationFromScratchGLSI_A.JWT_Bearer_Configuration;

namespace CoreApplicationFromScratchGLSI_A
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //services.Configure<IdentityOptions>
            //    (options =>
            //    {
            //        //Passwd settings
            //        options.Password.RequireUppercase = true;
            //        options.Password.RequireNonAlphanumeric = true;
            //        //Lockout setting
            //        options.Lockout.MaxFailedAccessAttempts = 5;
            //        //user settings
            //        options.User.RequireUniqueEmail = false;
            //    });
            // configure strongly typed settings objects	    
            var jwtSection = Configuration.GetSection("JwtBearerTokenSettings");
            services.Configure<JWTBearerTokenSetting>(jwtSection);
            var jwtBearerTokenSettings = jwtSection.Get<JWTBearerTokenSetting>();
            var key = System.Text.Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtBearerTokenSettings.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtBearerTokenSettings.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddControllersWithViews();
            services.AddRazorPages();
            //Ajout du service au DI container
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<ISubCategoryService,SubCategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
           // app.Use(async (context, next) =>
           // {
           //     await context.Response.WriteAsync("Hello World from 1st middelware");
           //     await next();
           // });
           // app.Run(async context =>
           //await context.Response.WriteAsync("Hello World from 2st middelware"));
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
