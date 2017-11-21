using CameraBazaar.Data;
using CameraBazaar.Data.Models;
using CameraBazaar.Services;
using CameraBazaar.Services.Contracts;
using CameraBazaar.Web.Infrastructure;
using CameraBazaar.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CameraBazaar.Web
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
            services.AddDbContext<CameraBazaarDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<CameraBazaarDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ICameraService, CameraService>();
            services.AddTransient<IUserService, UserService>();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                options.Filters.Add(new SimpleLogAttribute());
                options.Filters.Add(new ActionTimeAttribute());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

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