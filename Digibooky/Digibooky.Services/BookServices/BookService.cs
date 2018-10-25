﻿using Digibooky.Databases;
using Digibooky.Domain.Books;
using Digibooky.Services.BookServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Digibooky.Services.BookServices
{
    public class BookService : IBookService
    {
        public List<Book> GetAllBooks()
        {
            return BooksDatabase.booksDb;
        }

        public Book GetBookByISBN(string givenISBN)
        {

            var selectedBook = BooksDatabase.booksDb.FirstOrDefault(book => book.Isbn == givenISBN);
            if (selectedBook == null)
            { throw new Exception(); }
            else
            { return selectedBook; }
        }
    }
}
