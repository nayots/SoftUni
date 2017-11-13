using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Logs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CarDealerSystem.Web.Controllers
{
    public class LogsController : Controller
    {
        private const int MaxItemsPerPage = 3;
        private readonly ISimpleLoggerService simpleLoggerService;

        public LogsController(ISimpleLoggerService simpleLoggerService)
        {
            this.simpleLoggerService = simpleLoggerService;
        }

        [Authorize]
        public IActionResult All(MainLogsViewModel mainLogsViewModel)
        {
            mainLogsViewModel.Logs = this.simpleLoggerService.GetLogs(mainLogsViewModel.Search);

            bool enablePagination = mainLogsViewModel.Logs.Count() > MaxItemsPerPage;

            this.ViewData["Pagination"] = enablePagination;

            if (enablePagination)
            {
                var page = mainLogsViewModel.Page;

                var maxPages = (int)(Math.Ceiling(mainLogsViewModel.Logs.Count() / (double)MaxItemsPerPage));
                var currentPage = page < 0 ? 0 : page;
                currentPage = currentPage > maxPages ? maxPages - 1 : currentPage;

                mainLogsViewModel.Logs = mainLogsViewModel.Logs
                    .Skip((currentPage < 0 ? 0 : currentPage) * MaxItemsPerPage)
                    .Take((currentPage == 0 ? 1 : currentPage) * MaxItemsPerPage)
                    .ToList();

                this.ViewData["MaxPages"] = maxPages;
                this.ViewData["CurrentPage"] = currentPage;
            }

            return this.View(mainLogsViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Clear(MainLogsViewModel mainLogsViewModel)
        {
            this.simpleLoggerService.ClearLogs(mainLogsViewModel.Search);

            mainLogsViewModel.Search = string.Empty;
            mainLogsViewModel.Page = 0;

            return RedirectToAction(nameof(All), mainLogsViewModel);
        }
    }
}