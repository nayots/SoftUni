using LearningSystem.Common;
using LearningSystem.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    public class UserController : Controller
    {
        private IAdminUserService adminUserService;

        public UserController(IAdminUserService adminUserService)
        {
            this.adminUserService = adminUserService;
        }

        public IActionResult All()
        {
            var users = this.adminUserService.All();

            return View(users);
        }

        [HttpPost]
        public IActionResult AddRole(string userId, string role)
        {
            if (userId != null || role != null)
            {
                if (this.adminUserService.UserExistsById(userId) && this.adminUserService.RoleExists(role))
                {
                    this.adminUserService.AddRoleToUser(userId, role);
                }
            }
            else
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public IActionResult RemoveRole(string userId, string role)
        {
            if (userId != null || role != null)
            {
                if (this.adminUserService.UserExistsById(userId) && this.adminUserService.RoleExists(role))
                {
                    this.adminUserService.RemoveRoleToUser(userId, role);
                }
            }
            else
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}