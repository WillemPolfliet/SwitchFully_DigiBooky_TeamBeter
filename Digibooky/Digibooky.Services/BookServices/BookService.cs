using Digibooky.Databases;
using Digibooky.Databases.Books;
using Digibooky.Domain.Books;
using Digibooky.Services.BookServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Services.BookServices
{
    public class BookService : IBookService
    {
        public List<Book> GetAllBooks()
        {
            return BooksDatabase.booksDb;
        }
    }
}
