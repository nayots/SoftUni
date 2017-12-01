using LearningSystem.Services.Models.Admin.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Contracts
{
    public interface IAdminUserService
    {
        IEnumerable<UserRoleInfo> All();

        bool UserExistsById(string userId);

        bool RoleExists(string role);

        void AddRoleToUser(string userId, string role);

        void RemoveRoleToUser(string userId, string role);
    }
}