using System;
using System.Collections.Generic;
using System.Text;
using Digibooky.Databases;
using Digibooky.Domain.Books;

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
