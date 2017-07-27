using System;
using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    public Library(params Book[] books)
    {
        this.Books = new SortedSet<Book>(new BookComparator());
        foreach (var book in books)
        {
            this.Books.Add(book);
        }
    }

    private SortedSet<Book> Books { get; set; }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.Books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex;

        public LibraryIterator(SortedSet<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public Book Current { get { return this.books[this.currentIndex]; } }

        object IEnumerator.Current { get { return this.Current; } }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++currentIndex < this.books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}