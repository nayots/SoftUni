using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Parts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerSystem.Web.Controllers
{
    public class PartsController : Controller
    {
        private readonly IPartService partService;

        public PartsController(IPartService partService)
        {
            this.partService = partService;
        }

        public IActionResult All()
        {
            AllPartsModel model = this.partService.GetAllParts();

            return this.View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            EditDeletePartModel model = this.partService.GetPartInfo(id.Value);

            if (model is null)
            {
                return RedirectToAction("All");
            }

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditDeletePartModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.partService.UpdatePart(model);

                return RedirectToAction("All");
            }

            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            EditDeletePartModel model = this.partService.GetPartInfo(id.Value);

            if (model is null)
            {
                return RedirectToAction("All");
            }

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Delete(EditDeletePartModel model)
        {
            if (model.Id.HasValue)
            {
                this.partService.DeletePart(model.Id.Value);

                return RedirectToAction("All");
            }

            return View(model);
        }

        public IActionResult Add()
        {
            AddPartModel model = this.partService.GetPartModelWithSuppliers();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Add(AddPartModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.partService.AddPart(model);

                return RedirectToAction("Add");
            }

            model.Suppliers = this.partService.GetPartModelWithSuppliers().Suppliers;

            return this.View(model);
        }
    }
}