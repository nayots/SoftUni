using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
//06. Book Library Modification
namespace BookLibrary
{
    class BookLibraryTwo
    {
        static void Main(string[] args)
        {
            Library library = new Library() { Name = "SomeName", books = GetBooks() };
            string sDate = Console.ReadLine();
            DateTime specialDate = DateTime.ParseExact(sDate, "dd.MM.yyyy",CultureInfo.InvariantCulture);

            PrintResults(library, specialDate);
        }

        private static void PrintResults(Library library, DateTime specialDate)
        {

            foreach (var book in library.books.Where(x => x.Date > specialDate).OrderBy(y => y.Date).ThenBy(z => z.Title))
            {
                Console.WriteLine($"{book.Title} -> {book.Date.ToString("dd.MM.yyyy")}");
            }

        }

        public static List<Book> GetBooks()
        {
            int n = int.Parse(Console.ReadLine());
            List<Book> books = new List<Book>();

            for (int i = 0; i < n; i++)//{title} {author} {publisher} {release date} {ISBN} {price}.
            {
                string[] input = Console.ReadLine().Split();//29.07.1954
                DateTime date = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);

                Book book = new Book() { Title = input[0], Author = input[1], Publisher = input[2], Date = date, ISBN = input[4], Price = double.Parse(input[5]) };
                books.Add(book);
            }
            return books;
        }

    }

    class Book//title, author, publisher, release date, ISBN-number and price
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime Date { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> books { get; set; }
    }
}
