using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Suppliers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerSystem.Web.Controllers
{
    [Route("suppliers")]
    public class SuppliersController : Controller
    {
        private readonly ISupplierService supplierService;
        private readonly ISimpleLoggerService simpleLoggerService;

        public SuppliersController(ISupplierService supplierService, ISimpleLoggerService simpleLoggerService)
        {
            this.supplierService = supplierService;
            this.simpleLoggerService = simpleLoggerService;
        }

        [Route("{region}", Order = 2)]
        public IActionResult All(string region)
        {
            if (string.IsNullOrEmpty(region) || (!string.Equals(region, "local", System.StringComparison.OrdinalIgnoreCase) && !string.Equals(region, "importers", System.StringComparison.OrdinalIgnoreCase)))
            {
                return RedirectToAction("Index", "Home");
            }

            AllFilteredSuppliersModel model = this.supplierService.AllFiltered(region);

            return View("AllFiltered", model);
        }

        [Route("List", Order = 1)]
        public IActionResult List()
        {
            AllSuppliersModel suppliersModel = this.supplierService.All();

            return View(suppliersModel);
        }

        [Authorize]
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(AddSupplierModel addSupplierModel)
        {
            this.simpleLoggerService.LogToDb(this.User.Identity.Name, LogType.Add, "Suppliers");

            if (this.ModelState.IsValid)
            {
                this.supplierService.AddSupplier(addSupplierModel);

                this.TempData["Success"] = "Supplier added successfully.";

                return RedirectToAction(nameof(List));
            }

            this.TempData["Error"] = "There was an error with your request.";

            return View(addSupplierModel);
        }

        [Authorize]
        [Route("Edit/{id}")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                this.TempData["Error"] = "There was an error with your request.";

                return RedirectToAction(nameof(List));
            }

            SupplierModifyModel model = this.supplierService.GetEditModelById(id.Value);

            if (model is null)
            {
                this.TempData["Error"] = "There was an error with your request.";

                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(SupplierModifyModel supplierModifyModel)
        {
            this.simpleLoggerService.LogToDb(this.User.Identity.Name, LogType.Edit, "Suppliers");

            if (this.ModelState.IsValid)
            {
                this.supplierService.EditSupplier(supplierModifyModel);

                this.TempData["Success"] = "Supplier edited successfully.";

                return RedirectToAction(nameof(List));
            }

            this.TempData["Error"] = "There was an error with your request.";

            return View(supplierModifyModel);
        }

        [Authorize]
        [Route("Delete/{id}")]
        public IActionResult Delete(int? id)
        {
            this.simpleLoggerService.LogToDb(this.User.Identity.Name, LogType.Delete, "Suppliers");

            if (id != null || id > 0)
            {
                this.supplierService.DeleteById(id.Value);

                this.TempData["Success"] = "Supplier and parts removed.";

                return RedirectToAction(nameof(List));
            }

            this.TempData["Error"] = "There was an error with your request.";

            return RedirectToAction(nameof(List));
        }
    }
}