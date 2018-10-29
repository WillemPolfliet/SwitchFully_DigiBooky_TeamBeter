using Digibooky.Domain.Books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digibooky.Domain.Books
{
    public class Book
    {
        public Guid Id { get; }
        public string Isbn { get; private set; }
        public string Title { get; private set; }
        public string AuthorFirstName { get; private set; }
        public string AuthorLastName { get; private set; }

        public Book(string isbn, string title, string authorFirstName, string authorLastName)
        {
            Id = Guid.NewGuid();

            if (!isbn.All(Char.IsDigit))
            {
                throw new BookException("This ISBN contains a non-digit");
            }
            if (isbn.Length != 13)
            {
                throw new BookException("The ISBN must contain 13 digits");
            }
            Isbn = isbn;

            if(string.IsNullOrWhiteSpace(title))
            {
                throw new BookException("The title is required");
            }


            if (string.IsNullOrWhiteSpace(authorLastName))
            {
                throw new BookException("The authorLastName is required");
            }

            Title = title;
            AuthorFirstName = authorFirstName;
            AuthorLastName = authorLastName;
        }
    }
}
