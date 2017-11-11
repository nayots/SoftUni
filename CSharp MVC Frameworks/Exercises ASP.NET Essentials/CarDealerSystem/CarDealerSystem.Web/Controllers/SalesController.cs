using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerSystem.Web.Controllers
{
    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly ISalesService salesService;
        private readonly ISimpleLoggerService simpleLoggerService;

        public SalesController(ISalesService salesService, ISimpleLoggerService simpleLoggerService)
        {
            this.salesService = salesService;
            this.simpleLoggerService = simpleLoggerService;
        }

        [Route("{id?}")]
        public IActionResult All(int? id)
        {
            if (id is null)
            {
                AllSalesModel model = this.salesService.AllSales();

                return View("AllSales", model);
            }
            else
            {
                if (id <= 0)
                {
                    return NotFound();
                }

                SaleDetailsModel model = this.salesService.SaleDetails(id.Value);

                if (model is null)
                {
                    return NotFound();
                }

                return View("SaleDetails", model);
            }
        }

        [Route("discounted/{percent?}")]
        public IActionResult Discounted(double? percent)
        {
            this.ViewData["Percent"] = percent ?? -1;

            DiscountedSalesModel model = this.salesService.AllDiscountedSales(percent);

            return View(model);
        }

        [Route("add")]
        [Authorize]
        public IActionResult Add()
        {
            AddSaleModel addSaleModel = new AddSaleModel();

            addSaleModel.Cars = this.salesService.GetCarSaleModels();
            addSaleModel.Customers = this.salesService.GetCustomerSaleModels();

            return this.View(addSaleModel);
        }

        [Route("add")]
        [Authorize]
        [HttpPost]
        public IActionResult Add(AddSaleModel addSaleModel)
        {
            this.simpleLoggerService.LogToDb(this.User.Identity.Name, LogType.Add, "Sales");

            if (this.ModelState.IsValid)
            {
                FinalizeSaleModel finalizeSaleModel = this.salesService.GetFinalizeSaleInfo(addSaleModel.CarId, addSaleModel.CustomerId, addSaleModel.Discount);

                return this.RedirectToAction(nameof(ReviewSale), finalizeSaleModel);
            }

            addSaleModel.Cars = this.salesService.GetCarSaleModels();
            addSaleModel.Customers = this.salesService.GetCustomerSaleModels();

            return this.View(addSaleModel);
        }

        [Authorize]
        [HttpGet]
        [Route("ReviewSale")]
        public IActionResult ReviewSale(FinalizeSaleModel finalizeSaleModel)
        {
            if (finalizeSaleModel is null)
            {
                return this.RedirectToAction(nameof(Add));
            }

            return this.View(finalizeSaleModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Finalize(FinalizeSaleModel finalizeSaleModel)
        {
            if (finalizeSaleModel is null)
            {
                return this.RedirectToAction(nameof(Add));
            }

            this.salesService.AddSale(finalizeSaleModel.CarId, finalizeSaleModel.CustomerId, finalizeSaleModel.Discount);

            return this.RedirectToAction(nameof(All));
        }
    }
}