using Digibooky.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Books.Interfaces
{
    public interface IBookMapper
    {
        List<BookDTO> ListofBookToDTOObject(List<Book> givenListOfBooks);
        BookDTO ToDTO(Book givenBook);
    }
}
