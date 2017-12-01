using BookShop.Services.Contracts;
using BookShop.Web.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private const string InvalidCategoryRequestError = "A valid category id must be provided";
        private const string InvalidCategoryCreateError = "Category already exists";
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet()]
        public IActionResult All()
        {
            return Ok(this.categoryService.All());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            if (id.HasValue && this.categoryService.CategoryExists(id.Value))
            {
                return Ok(this.categoryService.GetbyId(id.Value));
            }

            return BadRequest(InvalidCategoryRequestError);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int? id, [FromBody]EditCategoryModel editCategoryModel)
        {
            if (id.HasValue && this.categoryService.CategoryExists(id.Value))
            {
                if (this.ModelState.IsValid)
                {
                    var result = this.categoryService.Edit(id.Value, editCategoryModel.Name);

                    return Ok(result);
                }

                return BadRequest(this.ModelState);
            }

            return NotFound(InvalidCategoryRequestError);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int? id)
        {
            if (id.HasValue && this.categoryService.CategoryExists(id.Value))
            {
                this.categoryService.Delete(id.Value);

                return Ok();
            }

            return BadRequest(InvalidCategoryRequestError);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateCategoryModel createCategoryModel)
        {
            if (this.ModelState.IsValid)
            {
                if (!this.categoryService.CategoryExists(createCategoryModel.Name))
                {
                    return Ok(this.categoryService.Create(createCategoryModel.Name));
                }

                return BadRequest(InvalidCategoryCreateError);
            }

            return BadRequest(this.ModelState);
        }
    }
}