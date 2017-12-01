using BookShop.Services.Contracts;
using BookShop.Web.Models.Authors;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private const string InvalidAuthorRequestError = "A valid author id must be provided";
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int? id)
        {
            if (id.HasValue && this.authorService.AuthorExists(id.Value))
            {
                return Ok(this.authorService.GetAuthorDetails(id.Value));
            }

            return NotFound(InvalidAuthorRequestError);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody]AuthorsCreateModel authorsCreateModel)
        {
            if (this.ModelState.IsValid)
            {
                var result = this.authorService.CreateAuthor(authorsCreateModel.FirstName, authorsCreateModel.LastName);

                return Ok(result);
            }

            return BadRequest(this.ModelState);
        }

        [HttpGet("{id}/books")]
        public IActionResult GetAuthorBooks(int? id)
        {
            if (id.HasValue && this.authorService.AuthorExists(id.Value))
            {
                return Ok(this.authorService.GetAuthorBooks(id.Value));
            }

            return NotFound(InvalidAuthorRequestError);
        }
    }
}