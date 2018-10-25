using Digibooky.Domain.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Services.BookServices.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
    }
}
