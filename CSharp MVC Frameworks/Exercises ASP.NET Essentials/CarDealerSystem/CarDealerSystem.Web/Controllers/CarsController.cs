using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerSystem.Web.Controllers
{
    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly ISimpleLoggerService simpleLoggerService;

        public CarsController(ICarService carService, ISimpleLoggerService simpleLoggerService)
        {
            this.carService = carService;
            this.simpleLoggerService = simpleLoggerService;
        }

        [Route("{make}")]
        public IActionResult All(string make)
        {
            if (string.IsNullOrEmpty(make))
            {
                return RedirectToAction("Index", "Home");
            }

            AllCarsFromMakeModel model = this.carService.AllFromMake(make);

            return View(model);
        }

        [Route("{id}/parts")]
        public IActionResult Parts(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var model = this.carService.CarWithParts(id);
            if (model is null)
            {
                return NotFound();
            }

            this.ViewData["CarId"] = id;
            return View(model);
        }

        [Authorize]
        [Route(nameof(Add))]
        public IActionResult Add()
        {
            AddCarModel model = this.carService.GetAddCarInfo();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Route(nameof(Add))]
        public IActionResult Add(AddCarModel addCarModel)
        {
            this.simpleLoggerService.LogToDb(this.User.Identity.Name, LogType.Add, "Cars");

            if (this.ModelState.IsValid)
            {
                this.carService.AddNewCar(addCarModel);

                return RedirectToAction("All", new { make = addCarModel.Make });
            }

            addCarModel.AvailableParts = this.carService.GetAddCarInfo().AvailableParts;

            return this.View(addCarModel);
        }
    }
}