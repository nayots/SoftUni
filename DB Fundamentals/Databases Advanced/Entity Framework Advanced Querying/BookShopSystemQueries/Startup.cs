using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.SqlClient;

namespace BookShopSystemQueries
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();

            //connection string used is .\SQLEXPRESS you can change it in the App.config if you need to.

            //1.Books Titles by Age Restriction
            //GetBooksByAgeRestriction();

            //2.Golden Books
            //GetGoldenBooks(context);

            //3.Books by Price
            //BooksByPrice(context);

            //4.Not Released Books
            //NotReleasedBooks(context);

            //5.Book Titles by Category
            //BooksByCategory(context);

            //6.Books Released Before Date
            //BooksReleasedBeforeDate(context);

            //7.Authors Search
            //AuthorSearch(context);

            //8.Books Search
            //BookSearch(context);

            //9.Book Titles Search
            //BookTitlesByAuthor(context);

            //10.Count Books
            //CountBooks(context);

            //11.Total Book Copies
            //TotalBookCopies(context);

            //12.Find Profit
            //FindProfit(context);

            //13.Most Recent Books
            //MostRecentBooks(context);

            //14.Increase Book Copies !Warning this will modify data in the Database!
            //IncreaseBookCopies(context);

            //15.Remove Books !Warning this will modify data in the Database!
            //RemoveBooks(context);

            //16.Stored Procedure !Warning this will modify data in the Database!
            //StoredProcedure(context);
        }

        private static void StoredProcedure(BookShopContext context)
        {
            //This is teh stored procedure code that's used.
            /*
            CREATE PROCEDURE usp_GetBooksCountByAuthor(@FirstName NVARCHAR(255), @LastName NVARCHAR(255))
            AS
            BEGIN
            
                SELECT COUNT(b.Id) AS BooksCount
            
                FROM Authors AS a
            
                INNER JOIN Books AS b
                ON b.AuthorId = a.Id
            
                WHERE LOWER(a.FirstName) = LOWER(@FirstName) AND LOWER(a.LastName) = LOWER(@LastName)
            END
            */

            Console.Write("Enter author First and Last name separated by space: ");

            string[] inputArgs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string query = @"EXEC usp_GetBooksCountByAuthor @FirstName, @LastName";

            SqlParameter firstName = new SqlParameter("@FirstName", inputArgs[0]);
            SqlParameter LastName = new SqlParameter("@LastName", inputArgs[1]);

            int number = context.Database.SqlQuery<int>(query, firstName, LastName).FirstOrDefault();

            Console.WriteLine($"{inputArgs[0]} {inputArgs[1]} has written {number} books");
        }

        private static void RemoveBooks(BookShopContext context)
        {
            int copies = 4200;//Change this if you want to try some othder number of copies

            var booksToRemove = context.Books
                .Where(b => b.Copies < copies)
                .ToList();
            int booksCountBeforeDelete = context.Books.Count();

            context.Books.RemoveRange(booksToRemove);

            context.SaveChanges();

            int booksAfterDelete = booksCountBeforeDelete - context.Books.Count();

            Console.WriteLine($"{booksAfterDelete} books were deleted");
        }

        private static void IncreaseBookCopies(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate > new DateTime(2013, 06, 06))
                .ToList();

            var booksCountBefore = books.Sum(x => x.Copies);

            foreach (var book in books)
            {
                book.Copies += 44;
            }

            var booksAddedCount = books.Sum(x => x.Copies) - booksCountBefore;

            context.SaveChanges();

            Console.WriteLine(booksAddedCount);
            Console.WriteLine($"{books.Count} books are released after 6 Jun 2013 so total of {booksAddedCount} book copies were added");

        }

        private static void MostRecentBooks(BookShopContext context)
        {
            var categoriesWithBooks = context.Categories
                .Select(s =>
                new
                {
                    CategoryName = s.Name,
                    BooksCount = s.Books.Count,
                    RecentBooks = s.Books.OrderByDescending(x => x.ReleaseDate)
                                         .ThenBy(t => t.Title)
                                         .Take(3)
                                         .Select(z => new { Title = z.Title, ReleaseDate = z.ReleaseDate })
                                         .ToList()
                }
                )
                .Where(w => w.BooksCount > 35)
                .OrderByDescending(o => o.BooksCount)
                .ToList();

            foreach (var catResult in categoriesWithBooks)
            {
                Console.WriteLine($"--{catResult.CategoryName}: {catResult.BooksCount} books");
                foreach (var book in catResult.RecentBooks)
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate.Year})");
                }
            }
        }

        private static void FindProfit(BookShopContext context)
        {
            var results = context.Categories
                .Select(s => new { CategoryName = s.Name, Profit = s.Books.Sum(b => b.Copies * b.Price) })
                .OrderByDescending(p => p.Profit).ThenBy(a => a.CategoryName)
                .ToList();

            foreach (var result in results)
            {
                Console.WriteLine($"{result.CategoryName} - ${result.Profit:F2}");
            }
        }

        private static void TotalBookCopies(BookShopContext context)
        {
            var authors = context.Authors
                .Select(s => new { AuthorName = s.FirstName + " " + s.LastName, BooksCount = s.Books.Sum(x => x.Copies) })
                .OrderByDescending(o => o.BooksCount)
                .ToList();

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.AuthorName} - {author.BooksCount}");
            }
        }

        private static void CountBooks(BookShopContext context)
        {
            int titleLength = 0;
            Console.Write("Enter a title length: ");
            while (!int.TryParse(Console.ReadLine(), out titleLength))
            {
                Console.Write("Enter a valid number for title length: ");
            }

            int count = context.Books
                .Where(b => b.Title.Length > titleLength)
                .Count();
            Console.WriteLine(count);
            Console.WriteLine($"There are {count} books with longer title than {titleLength} symbols");
        }

        private static void BookTitlesByAuthor(BookShopContext context)
        {
            Console.Write("Enter search arguments: ");
            string searchArg = Console.ReadLine().ToLower();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(searchArg))
                .OrderBy(o => o.Id)
                .Select(s => new { Title = s.Title, AuthorName = s.Author.FirstName + " " + s.Author.LastName })
                .ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} ({book.AuthorName})");
            }
        }

        private static void BookSearch(BookShopContext context)
        {
            Console.Write("Enter search string: ");
            string searchArg = Console.ReadLine().ToLower();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(searchArg))
                .Select(s => s.Title)
                .ToList();
            Console.WriteLine(string.Join("\n", books));
        }

        private static void AuthorSearch(BookShopContext context)
        {
            Console.WriteLine("Enter search string: ");
            var searchStr = Console.ReadLine();

            var authors = context.Authors
                .Where(n => n.FirstName.EndsWith(searchStr))
                .Select(s => new { FullName = s.FirstName + " " + s.LastName })
                .ToList();

            foreach (var author in authors)
            {
                Console.WriteLine(author.FullName);
            }
        }

        private static void BooksReleasedBeforeDate(BookShopContext context)
        {
            DateTime date = new DateTime();
            Console.Write("Enter date (dd-MM-yyyy): ");
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.Write("Enter a valid date (dd-MM-yyyy): ");
            }

            var books = context.Books
                .Where(b => b.ReleaseDate < date)
                .Select(s => new { Title = s.Title, Edition = s.EditionType, Price = s.Price })
                .ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.Edition} - {book.Price:F2}");
            }
        }

        private static void BooksByCategory(BookShopContext context)
        {
            Console.WriteLine("Enter categories:");
            var categories = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            //b.Categories.Any can we replaced with b.Categories.All 
            //if we want to match books that have all of the categories mentioned

            var books = context.Books
                .Where(b => b.Categories.Any(s => categories.Select(x => x.ToLower()).ToList().Contains(s.Name.ToLower())))
                .OrderBy(x => x.Id)
                .Select(s => s.Title)
                .ToList();
            Console.WriteLine("Books with matching category: ");
            Console.WriteLine(string.Join("\n", books));
        }

        private static void NotReleasedBooks(BookShopContext context)
        {
            Console.WriteLine("Enter year: ");
            int year = 0;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.Write("Enter a valid number for year: ");
            }

            var books = context.Books
                .Where(b => b.ReleaseDate.Year != year)
                .OrderBy(o => o.Id)
                .Select(s => s.Title)
                .ToList();

            Console.WriteLine(string.Join("\n", books));

        }

        private static void BooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price < 5 || b.Price > 40)
                .OrderBy(o => o.Id)
                .Select
                (s => new
                {
                    Title = s.Title,
                    Price = s.Price
                })
                .ToList();
            Console.WriteLine("Books under 5$ and over 40$ :");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - ${book.Price:F2}");
            }
        }

        private static void GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(o => o.Id)
                .Select(s => s.Title)
                .ToList();
            Console.WriteLine("Golden books titles:");
            Console.WriteLine(string.Join("\n", goldenBooks));
        }

        private static void GetBooksByAgeRestriction()
        {
            Console.Write("Enter age group (Minor, Teen or Adult): ");

            string ageGroup = Console.ReadLine().ToLower();
            using (var context = new BookShopContext())
            {
                //Minor 0
                //Teen  1
                //Adult 2
                AgeRestriction ageRest = new AgeRestriction();

                switch (ageGroup)
                {
                    case "minor":
                        ageRest = AgeRestriction.Minor;
                        break;
                    case "teen":
                        ageRest = AgeRestriction.Teen;
                        break;
                    case "adult":
                        ageRest = AgeRestriction.Adult;
                        break;
                    default:
                        ageRest = AgeRestriction.Adult;
                        Console.WriteLine("Your input does not match any age group, the default group is Adult.");
                        break;
                }

                var books = context.Books
                    .Where(a => a.AgeRestriction == ageRest)
                    .Select(s => s.Title)
                    .ToList();

                foreach (var bookTitle in books)
                {
                    Console.WriteLine(bookTitle);
                }
            }
        }
    }
}
