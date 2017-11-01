using JudgeSystem.App.Services.Contracts;
using SimpleMvc.Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Controllers
{
    public class HomeController : BaseController
    {
        private IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            if (!this.User.IsAuthenticated)
            {
                this.ViewModel["user-name"] = "Hello, guest!";
                this.ViewModel["welcome-message"] = "Please login in our system in order to use it.";
                this.ViewModel["anonymousDisplay"] = "inline-block";
                this.ViewModel["line"] = "block";
            }
            else
            {
                var user = this.userService.GetUserByEmail(this.User.Name);

                this.ViewModel["userDisplay"] = "inline-block";

                this.ViewModel["user-name"] = $"Hello, {user.FullName}!";
                this.ViewModel["welcome-message"] = "You can view all contests or review your submissions.";
                this.ViewModel["line"] = "none";
            }

            return View();
        }
    }
}