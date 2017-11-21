using CameraBazaar.Services.Contracts;
using CameraBazaar.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraBazaar.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService userService;

        public AdminController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult All()
        {
            IEnumerable<UserSellerStatusModel> userSellerStatusModels = userService.GetAllUsersInfo();

            return View(userSellerStatusModels);
        }

        public IActionResult ChangeStatus(string username)
        {
            if (username != null)
            {
                if (this.userService.UserExistsByUsername(username))
                {
                    this.userService.ChangeStatus(username);

                    return RedirectToAction(nameof(All));
                }
            }

            return BadRequest();
        }
    }
}