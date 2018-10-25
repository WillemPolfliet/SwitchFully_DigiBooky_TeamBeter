using Digibooky.Domain.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Books
{
    public class Book
    {
        public Giud Id { get; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }

        public Book(string isbn, string title, Author author)
        {
            Id = new Giud();
            Isbn = isbn;
            Title = title;
            Author = author;
        }
    }
}
