using LearningSystem.Common.AutoMapper;
using LearningSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace LearningSystem.Services.Models.Admin.Users
{
    public class UserRoleInfo : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public ICollection<string> Roles { get; set; } = new List<string>();
    }
}