using CameraBazaar.Services.Contracts;
using CameraBazaar.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CameraBazaar.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICameraService cameraService;

        public HomeController(ICameraService cameraService)
        {
            this.cameraService = cameraService;
        }

        public IActionResult Index()
        {
            var cameras = this.cameraService.GetAllCamerasDetails();

            return View(cameras);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}