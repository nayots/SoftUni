using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;

namespace SimpleMvc.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}