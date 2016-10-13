using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
//05. Book Library
namespace BookLibrary
{
    class BookLibrary
    {
        static void Main(string[] args)
        {
            Library library = new Library() { Name = "SomeName", books = GetBooks() };

            PrintResults(library);
        }

        private static void PrintResults(Library library)
        {

            foreach (var books in library.books.GroupBy(x => x.Author).OrderByDescending(x => x.Sum(y => y.Price)).ThenBy(z => z.Key))
            {
                Console.WriteLine($"{books.Key} -> {books.Sum(x => x.Price):f2}");
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
