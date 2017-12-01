using LearningSystem.Services.Contracts;
using LearningSystem.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Services.Models.Admin.Users;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using LearningSystem.Data.Models;

namespace LearningSystem.Services
{
    public class AdminUserService : IAdminUserService
    {
        private LearningSystemDbContext db;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public AdminUserService(LearningSystemDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void AddRoleToUser(string userId, string role)
        {
            var user = this.db.Users.First(u => u.Id == userId);
            Task.Run(async () =>
            {
                var userRoles = await this.userManager.GetRolesAsync(user);

                if (!userRoles.Contains(role) && await this.roleManager.RoleExistsAsync(role))
                {
                    await this.userManager.AddToRoleAsync(user, role);
                }
            }).Wait();
        }

        public IEnumerable<UserRoleInfo> All()
        {
            var users = this.db.Users.ProjectTo<UserRoleInfo>().ToList();

            for (int i = 0; i < users.Count; i++)
            {
                Task.Run(async () =>
                {
                    var user = await this.userManager.FindByIdAsync(users[i].Id);

                    var roles = await this.userManager.GetRolesAsync(user);

                    users[i].Roles = roles;
                }).Wait();
            }

            return users;
        }

        public void RemoveRoleToUser(string userId, string role)
        {
            var user = this.db.Users.First(u => u.Id == userId);
            Task.Run(async () =>
            {
                var userRoles = await this.userManager.GetRolesAsync(user);

                if (userRoles.Contains(role) && await this.roleManager.RoleExistsAsync(role))
                {
                    await this.userManager.RemoveFromRoleAsync(user, role);
                }
            }).Wait();
        }

        public bool RoleExists(string role)
        {
            return Task.Run(async () => await this.roleManager.RoleExistsAsync(role)).Result;
        }

        public bool UserExistsById(string userId)
        {
            return this.db.Users.Any(u => u.Id == userId);
        }
    }
}