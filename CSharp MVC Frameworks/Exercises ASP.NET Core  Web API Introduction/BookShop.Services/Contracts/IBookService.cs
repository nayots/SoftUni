using BookShop.Services.Models.Books;
using System;
using System.Collections.Generic;

namespace BookShop.Services.Contracts
{
    public interface IBookService
    {
        bool BookExists(int id);

        BookFullDetailsModel GetBookDetails(int id);

        IEnumerable<BookShortDetailsModel> AllSearchResults(string search);

        BookFullDetailsModel CreateBook(string title, string description, decimal price, int copies, string edition, int ageRestriction, DateTime releaseDate, int authorId, IEnumerable<string> categories);

        void DeleteBook(int id);

        BookFullDetailsModel Edit(int id, string title, string description, decimal price, int copies, string edition, int ageRestriction, DateTime releaseDate, int authorId);
    }
}