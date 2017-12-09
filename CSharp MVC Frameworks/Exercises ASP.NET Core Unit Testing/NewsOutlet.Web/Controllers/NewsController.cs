using Microsoft.AspNetCore.Mvc;
using NewsOutlet.Common;
using NewsOutlet.Services.Contracts;
using NewsOutlet.Web.Models;

namespace NewsOutlet.Web.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet]
        public IActionResult All()
        {
            return this.Ok(this.newsService.GetAllNewsOrdered());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            if (id.HasValue && this.newsService.Exists(id.Value))
            {
                var result = this.newsService.GetBasicInfo(id.Value);

                return this.Ok(result);
            }

            return BadRequest(GlobalConstants.NoValidIdProvided);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateEditNewsModel createEditNewsModel)
        {
            if (this.ModelState.IsValid)
            {
                var result = this.newsService.Create(createEditNewsModel.Title, createEditNewsModel.Content, createEditNewsModel.PublishDate.Value);

                if (result != null)
                {
                    return this.Ok(result);
                }
            }

            return BadRequest(this.ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int? id, [FromBody]CreateEditNewsModel createEditNewsModel)
        {
            if (id.HasValue && this.ModelState.IsValid && this.newsService.Exists(id.Value))
            {
                var result = this.newsService.Update(id.Value, createEditNewsModel.Title, createEditNewsModel.Content, createEditNewsModel.PublishDate.Value);

                if (result != null)
                {
                    return this.Ok(result);
                }
            }
            if (id is null || !this.newsService.Exists(id.Value))
            {
                this.ModelState.AddModelError("Id", GlobalConstants.NoValidIdProvided);
            }

            return BadRequest(this.ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && this.newsService.Exists(id.Value))
            {
                this.newsService.Delete(id.Value);

                return this.Ok(GlobalConstants.ItemDeletedMessage);
            }

            return BadRequest(GlobalConstants.NoValidIdProvided);
        }
    }
}