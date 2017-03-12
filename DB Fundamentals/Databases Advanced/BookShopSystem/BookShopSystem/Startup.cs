using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
using System.Data.Entity;

namespace BookShopSystem
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new BookShopDBContext();

            context.Database.Initialize(true);


            var bookcount = context.Books.Count();
            Console.WriteLine(bookcount);

            var books = context.Books.Take(3).ToList();

            //Ruun the following lines ONLY once! Or it will print the books 2 times.
            //books[0].RelatedBooks.Add(books[1]);
            //books[1].RelatedBooks.Add(books[0]);
            //books[0].RelatedBooks.Add(books[2]);
            //books[2].RelatedBooks.Add(books[0]);

            context.SaveChanges();

            var booksFromQuery = context.Books.Take(3);


            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
                Console.WriteLine();
            }

        }
    }
}
