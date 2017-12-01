using AutoMapper.QueryableExtensions;
using BookShop.Data;
using BookShop.Data.Models;
using BookShop.Services.Contracts;
using BookShop.Services.Models.Authors;
using BookShop.Services.Models.Books;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext bookShopDbContext)
        {
            this.db = bookShopDbContext;
        }

        public bool AuthorExists(int id)
        {
            return this.db.Authors.Any(a => a.Id == id);
        }

        public AuthorDetailsModel CreateAuthor(string firstName, string lastName)
        {
            Author author = new Author()
            {
                FirstName = firstName,
                LastName = lastName
            };

            this.db.Authors.Add(author);
            this.db.SaveChanges();

            return this.GetAuthorDetails(author.Id);
        }

        public IEnumerable<BookFullDetailsModel> GetAuthorBooks(int id)
        {
            return this.db.Books.Where(b => b.AuthorId == id)
                .ProjectTo<BookFullDetailsModel>().ToList();
        }

        public AuthorDetailsModel GetAuthorDetails(int id)
        {
            return this.db.Authors.Where(a => a.Id == id)
                .ProjectTo<AuthorDetailsModel>().First();
        }
    }
}