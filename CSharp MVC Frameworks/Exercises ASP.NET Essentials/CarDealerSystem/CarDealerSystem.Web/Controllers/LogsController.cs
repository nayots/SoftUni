using CarDealerSystem.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CarDealerSystem.Web.Controllers
{
    public class LogsController : Controller
    {
        private const int MaxItemsPerPage = 20;
        private readonly ISimpleLoggerService simpleLoggerService;

        public LogsController(ISimpleLoggerService simpleLoggerService)
        {
            this.simpleLoggerService = simpleLoggerService;
        }

        [Authorize]
        public IActionResult All(string username, int page)
        {
            var model = this.simpleLoggerService.GetLogs(username);

            bool enablePagination = model.Logs.Count() > MaxItemsPerPage;

            this.ViewData["Pagination"] = enablePagination;
            this.ViewData["Username"] = username;

            if (username != null && username.Length > 0)
            {
                this.TempData["Username"] = username;
            }
            else
            {
                if (this.TempData.ContainsKey("Username"))
                {
                    username = this.TempData["Username"] as string;
                    this.TempData["Username"] = username;
                }
            }

            if (enablePagination)
            {
                var maxPages = (int)(Math.Ceiling(model.Logs.Count() / (double)MaxItemsPerPage));
                var currentPage = page < 0 ? 0 : page;
                currentPage = currentPage > maxPages ? maxPages - 1 : currentPage;

                model.Logs = model.Logs
                    .Skip((currentPage < 0 ? 0 : currentPage) * MaxItemsPerPage)
                    .Take((currentPage == 0 ? 1 : currentPage) * MaxItemsPerPage)
                    .ToList();

                this.ViewData["MaxPages"] = maxPages;
                this.ViewData["CurrentPage"] = currentPage;
            }

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Clear(string username)
        {
            if (username is null && this.TempData.ContainsKey("Username"))
            {
                username = this.TempData["Username"] as string;
            }

            this.simpleLoggerService.ClearLogs(username);

            return RedirectToAction(nameof(All), new { username = "", page = 0 });
        }
    }
}