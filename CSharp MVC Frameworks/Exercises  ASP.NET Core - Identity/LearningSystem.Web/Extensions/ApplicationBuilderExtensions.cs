using LearningSystem.Common;
using LearningSystem.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<LearningSystemDbContext>().Database.Migrate();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var adminRoleExists = await roleManager.RoleExistsAsync(GlobalConstants.AdminRoleName);
                    if (!adminRoleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(GlobalConstants.AdminRoleName));
                    }

                    var studentRoleExists = await roleManager.RoleExistsAsync(GlobalConstants.StudentRoleName);
                    if (!studentRoleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(GlobalConstants.StudentRoleName));
                    }

                    var trainerRoleExists = await roleManager.RoleExistsAsync(GlobalConstants.TrainerRoleName);
                    if (!trainerRoleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(GlobalConstants.TrainerRoleName));
                    }

                    var blogAuthorRoleExists = await roleManager.RoleExistsAsync(GlobalConstants.BlogAuthorRolename);
                    if (!blogAuthorRoleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(GlobalConstants.BlogAuthorRolename));
                    }
                }).Wait();
            }

            return app;
        }
    }
}