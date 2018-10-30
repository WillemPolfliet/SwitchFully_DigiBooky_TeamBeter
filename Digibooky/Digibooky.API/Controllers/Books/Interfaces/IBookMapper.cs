using Digibooky.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Books.Interfaces
{
    public interface IBookMapper
    {
        List<BookDTO> ListofBookToDTOList(List<Book> givenListOfBooks);
        BookDTO BookToDTO(Book givenBook);
        BookDTODetails BookToDetailsDTO(Dictionary<Book, string> givenBook);
        Book BookDTORegisterToBook(BookDTORegister bookDTO);
    }
}
