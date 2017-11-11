using CarDealerSystem.Data.Models;
using CarDealerSystem.Services;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDealerSystem.Web
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
            services.AddDbContext<CarDealerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<CarDealerDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<ISalesService, SalesService>();
            services.AddTransient<IPartService, PartService>();
            services.AddTransient<ISimpleLoggerService, SimpleLoggerService>();

            // Add application services.

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMvc();
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
                //routes.MapRoute(
                //    name: "customers",
                //    template: "customers/all/{order}",
                //    defaults: new { controller = "Customers", action = "All" }
                //    );

                //routes.MapRoute(
                //    name: "customersSummary",
                //    template: "customers/{id}",
                //    defaults: new { controller = "Customers", action = "Summary" }
                //    );

                //routes.MapRoute(
                //    name: "cars",
                //    template: "cars/{make}",
                //    defaults: new { controller = "Cars", action = "All" }
                //    );

                //routes.MapRoute(
                //    name: "carsParts",
                //    template: "cars/{id}/parts",
                //    defaults: new { controller = "Cars", action = "Parts" }
                //    );

                //routes.MapRoute(
                //     name: "suppliers",
                //     template: "suppliers/{region}",
                //     defaults: new { controller = "Suppliers", action = "All" }
                //     );
                //routes.MapRoute(
                //     name: "salesDiscounts",
                //     template: "sales/discounted/{percent?}",
                //     defaults: new { controller = "Sales", action = "Discounted" }
                //     );
                //routes.MapRoute(
                //     name: "sales",
                //     template: "sales/{id?}",
                //     defaults: new { controller = "Sales", action = "All" }
                //     );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}