using FDMC.Data;
using FDMC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;

namespace FDMC.App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FdmcDbContext>(options => options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FDMCDB;Integrated Security=True"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Type", "text/html");
                //context.RequestServices.GetService<FdmcDbContext>().Database.EnsureCreated();
                await next();
            });

            app.MapWhen(
                ctx => ctx.Request.Path.Value == "/"
                && ctx.Request.Method == "GET",
                home =>
                {
                    home.Run(async (context) =>
                    {
                        var db = context.RequestServices.GetService<FdmcDbContext>();

                        var catsData = db.Cats.Select(c => new
                        {
                            c.Id,
                            c.Name
                        }).ToList();

                        await context.Response.WriteAsync("<h1>Fluffy Duffy Munchkin Cats</h1>");

                        await context.Response.WriteAsync("<ul>");

                        foreach (var catLink in catsData)
                        {
                            await context.Response.WriteAsync($@"<li><a href=""/cat/{catLink.Id}"">{catLink.Name}</a></li>");
                        }

                        await context.Response.WriteAsync("</ul>");

                        await context.Response.WriteAsync(@"<a href=""/cat/add""><button>Add Cat</button></a>");
                    });
                });

            app.MapWhen(
                ctx => ctx.Request.Path.Value == "/cat/add",
                    add =>
                    {
                        add.Run(async (context) =>
                        {
                            if (context.Request.Method == "GET")
                            {
                                context.Response.Redirect("/add.html");
                            }
                            else
                            {
                                try
                                {
                                    var formData = context.Request.Form;

                                    string catName = formData["catName"];
                                    int catAge = int.Parse(formData["catAge"]);
                                    string catBreed = formData["catBreed"];
                                    string catImg = formData["catImg"];

                                    var cat = new Cat()
                                    {
                                        Name = catName,
                                        Age = catAge,
                                        Breed = catBreed,
                                        ImageUrl = catImg
                                    };

                                    var db = context.RequestServices.GetService<FdmcDbContext>();
                                    using (db)
                                    {
                                        db.Cats.Add(cat);
                                        await db.SaveChangesAsync();
                                    }

                                    context.Response.Redirect("/");
                                }
                                catch (Exception)
                                {
                                    await context.Response.WriteAsync("<h3>Invalid data ;(</h3>");
                                }
                            }
                        });
                    }
                );

            app.MapWhen(
                ctx => ctx.Request.Path.Value.StartsWith("/cat/"),
                info =>
                    {
                        info.Run(async (context) =>
                        {
                            var urlTokens = context.Request.Path.Value.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

                            if (urlTokens.Length > 1 && urlTokens.Length == 2 && int.TryParse(urlTokens[1], out int id))
                            {
                                var db = context.RequestServices.GetService<FdmcDbContext>();

                                Cat cat = null;

                                using (db)
                                {
                                    cat = db.Cats.FirstOrDefault(c => c.Id == id);
                                }

                                if (cat is null)
                                {
                                    await context.Response.WriteAsync($"No cat with id {id} found =/");
                                }

                                var sb = new StringBuilder();

                                sb.AppendLine($"<h1>{cat.Name}</h1>");
                                sb.AppendLine("<br/>");
                                sb.AppendLine($@"<img src=""{cat.ImageUrl}"" style=""max-width:300px"" alt=""cat"" />");
                                sb.AppendLine("<br/>");
                                sb.AppendLine($@"<strong>Age: {cat.Age}</strong>");
                                sb.AppendLine("<br/>");
                                sb.AppendLine($@"<strong>Breed: {cat.Breed}</strong>");

                                await context.Response.WriteAsync(sb.ToString());
                            }

                            await context.Response.WriteAsync("Invalid Cat Id =/");
                        });
                    }
                );

            app.Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("404, Page not found :(");
            });
        }
    }
}