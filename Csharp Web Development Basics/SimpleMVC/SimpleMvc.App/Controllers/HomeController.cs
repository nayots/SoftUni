using SimpleMvc.Framework.Contracts;
using SimpleMvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvc.App.Controllers
{
    public class HomeController : Controller
    {
        protected HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}