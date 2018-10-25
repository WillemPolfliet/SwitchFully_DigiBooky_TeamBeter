using Digibooky.API.Controllers.Authors;
using Digibooky.API.Controllers.Authors.Interfaces;
using Digibooky.API.Controllers.Books.Interfaces;
using Digibooky.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Digibooky.Domain.Books.Book;

namespace Digibooky.API.Controllers.Books
{
    public class BookMapper : IBookMapper
    {
        public List<BookDTO> ListofBookToDTOObject(List<Book> givenListOfBooks)
        {
            List<BookDTO> dtos = new List<BookDTO>();

            foreach (var book in givenListOfBooks)
            {
                dtos.Add(BookToDTO(book));
            }

            return dtos;
        }

        public BookDTO BookToDTO(Book givenBook)
        {
            AuthorMapper authorMapper = new AuthorMapper();

            return new BookDTO
            {
                Isbn = givenBook.Isbn,
                Title = givenBook.Title,
                AuthorDTO = authorMapper.AuthorToDTO(givenBook.Author)
            };
        }
    }
}
