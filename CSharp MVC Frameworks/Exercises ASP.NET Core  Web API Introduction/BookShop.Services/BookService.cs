using AutoMapper.QueryableExtensions;
using BookShop.Data;
using BookShop.Data.Models;
using BookShop.Services.Contracts;
using BookShop.Services.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Services
{
    public class BookService : IBookService
    {
        private readonly BookShopDbContext db;

        public BookService(BookShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BookShortDetailsModel> AllSearchResults(string search)
        {
            search = search is null ? "" : search;

            return this.db.Books.Where(b => b.Title.ToLower().Contains(search.ToLower()))
                .OrderBy(b => b.Title)
                .Take(10)
                .ProjectTo<BookShortDetailsModel>();
        }

        public bool BookExists(int id)
        {
            return this.db.Books.Any(b => b.Id == id);
        }

        public BookFullDetailsModel CreateBook(string title, string description, decimal price, int copies, string edition, int ageRestriction, DateTime releaseDate, int authorId, IEnumerable<string> categories)
        {
            var book = new Book()
            {
                Title = title,
                Description = description,
                Price = price,
                Copies = copies,
                Edition = edition,
                AgeRestriction = ageRestriction,
                ReleaseDate = releaseDate
            };

            if (!this.db.Authors.Any(a => a.Id == authorId))
            {
                return null;
            }

            book.AuthorId = authorId;

            if (categories != null)
            {
                foreach (var category in categories)
                {
                    var cat = this.db.Categories.FirstOrDefault(c => c.Name == category);

                    if (cat is null)
                    {
                        cat = new Category()
                        {
                            Name = category
                        };

                        this.db.Categories.Add(cat);
                        this.db.SaveChanges();
                    }

                    book.Categories.Add(new CategoryBook()
                    {
                        CategoryId = cat.Id
                    });
                }
            }

            this.db.Books.Add(book);
            this.db.SaveChanges();

            return this.GetBookDetails(book.Id);
        }

        public void DeleteBook(int id)
        {
            var book = this.db.Books.FirstOrDefault(b => b.Id == id);

            this.db.Remove(book);
            this.db.SaveChanges();
        }

        public BookFullDetailsModel Edit(int id, string title, string description, decimal price, int copies, string edition, int ageRestriction, DateTime releaseDate, int authorId)
        {
            if (!this.db.Authors.Any(a => a.Id == authorId))
            {
                return null;
            }

            var book = this.db.Books.First(b => b.Id == id);

            book.Title = title;
            book.Description = description;
            book.Price = price;
            book.Copies = copies;
            book.Edition = edition;
            book.AgeRestriction = ageRestriction;
            book.ReleaseDate = releaseDate;
            book.AuthorId = authorId;

            this.db.SaveChanges();

            return this.GetBookDetails(book.Id);
        }

        public BookFullDetailsModel GetBookDetails(int id)
        {
            return this.db.Books.Where(b => b.Id == id)
                .ProjectTo<BookFullDetailsModel>().First();
        }
    }
}