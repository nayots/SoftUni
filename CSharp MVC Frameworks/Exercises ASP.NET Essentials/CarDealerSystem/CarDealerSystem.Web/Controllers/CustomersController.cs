using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarDealerSystem.Web.Controllers
{
    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Route("all/{order}")]
        public IActionResult All(string order)
        {
            if (string.IsNullOrEmpty(order) || (!string.Equals(order, "ascending", System.StringComparison.OrdinalIgnoreCase) && !string.Equals(order, "descending", System.StringComparison.OrdinalIgnoreCase)))
            {
                return RedirectToAction("Index", "Home");
            }

            AllCustomersModel model = this.customerService.All(order);

            return View(model);
        }

        [Route("{id}")]
        public IActionResult Summary(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var model = this.customerService.Summary(id);

            return View(model);
        }

        [Route("Add")]
        public IActionResult Add()
        {
            return View(new AddCustomerModel() { Birthday = DateTime.Now });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Add")]
        public IActionResult Add(AddCustomerModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.customerService.AddCustomer(model);

                return RedirectToAction("All", new { order = "ascending" });
            }

            return View(model);
        }

        [Route("Edit")]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            CustomerEditDeleteModel model = this.customerService.GetUserEditDeleteModelById(id);

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Edit")]
        public IActionResult Edit(CustomerEditDeleteModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.customerService.UpdateCustomer(model);

                return RedirectToAction("All", new { order = "ascending" });
            }

            return View(model);
        }
    }
}