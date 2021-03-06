﻿using Digibooky.Domain.Books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digibooky.Domain.Books
{
    public class Book
    {
        public Guid Id { get; }
        public string ISBN { get; private set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public bool IsDeleted { get; set; }

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
            ISBN = isbn;

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
            IsDeleted = false;
        }
    }
}
