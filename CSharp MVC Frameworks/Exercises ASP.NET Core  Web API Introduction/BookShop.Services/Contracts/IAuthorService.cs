using BookShop.Services.Models.Authors;
using BookShop.Services.Models.Books;
using System.Collections.Generic;

namespace BookShop.Services.Contracts
{
    public interface IAuthorService
    {
        bool AuthorExists(int id);

        AuthorDetailsModel GetAuthorDetails(int id);

        AuthorDetailsModel CreateAuthor(string firstName, string lastName);

        IEnumerable<BookFullDetailsModel> GetAuthorBooks(int id);
    }
}