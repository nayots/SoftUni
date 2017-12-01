using BookShop.Services.Contracts;
using BookShop.Web.Models.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private const string InvalidBookRequestError = "A valid book id must be provided";
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int? id)
        {
            if (id.HasValue && this.bookService.BookExists(id.Value))
            {
                return this.Ok(this.bookService.GetBookDetails(id.Value));
            }

            return NotFound(InvalidBookRequestError);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id.HasValue && this.bookService.BookExists(id.Value))
            {
                this.bookService.DeleteBook(id.Value);

                return this.Ok();
            }

            return NotFound(InvalidBookRequestError);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int? id, [FromBody]EditBookModel editBookModel)
        {
            if (id.HasValue && this.bookService.BookExists(id.Value))
            {
                if (this.ModelState.IsValid)
                {
                    var result = this.bookService.Edit(id.Value, editBookModel.Title, editBookModel.Description, editBookModel.Price, editBookModel.Copies, editBookModel.Edition, editBookModel.AgeRestriction, editBookModel.ReleaseDate, editBookModel.AuthorId);

                    if (result is null)
                    {
                        return BadRequest();
                    }

                    return Ok(result);
                }

                return BadRequest(this.ModelState);
            }

            return NotFound(InvalidBookRequestError);
        }

        [HttpGet]
        public IActionResult Search([FromQuery]string search)
        {
            return Ok(this.bookService.AllSearchResults(search));
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateBookModel createBookModel)
        {
            if (this.ModelState.IsValid)
            {
                var result = this.bookService.CreateBook(createBookModel.Title, createBookModel.Description, createBookModel.Price, createBookModel.Copies, createBookModel.Edition, createBookModel.AgeRestriction, createBookModel.ReleaseDate, createBookModel.AuthorId, createBookModel.Categories);

                if (result is null)
                {
                    return BadRequest();
                }

                return Ok(result);
            }

            return BadRequest(this.ModelState);
        }
    }
}