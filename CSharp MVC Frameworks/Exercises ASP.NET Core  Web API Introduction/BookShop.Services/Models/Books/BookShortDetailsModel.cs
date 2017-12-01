using BookShop.Common.AutoMapper;
using BookShop.Data.Models;

namespace BookShop.Services.Models.Books
{
    public class BookShortDetailsModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}