using Digibooky.Domain.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Books
{
    public class Book
    {
        public Guid Id { get; }
        public string Isbn { get; private set; }
        public string Title { get; private set; }
        public Author Author { get; private set; } //TODO ID ?

        public Book(string isbn, string title, Author author)
        {
            Id = Guid.NewGuid();
            Isbn = isbn;
            Title = title;
            Author = author;
        }
    }
}
