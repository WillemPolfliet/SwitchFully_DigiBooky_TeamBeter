using Digibooky.API.Controllers.Books.Interfaces;
using Digibooky.Domain.Books;
using System;
using System.Collections.Generic;

namespace Digibooky.API.Controllers.Books
{
    public class BookMapper : IBookMapper
    {
        public List<BookDTO> ListofBookToDTOList(List<Book> givenListOfBooks)
        {
            List<BookDTO> dtoList = new List<BookDTO>();

            foreach (var book in givenListOfBooks)
            {
                dtoList.Add(BookToDTO(book));
            }

            return dtoList;
        }

        public BookDTO BookToDTO(Book givenBook)
        {
            return new BookDTO
            {
                Isbn = givenBook.Isbn,
                Title = givenBook.Title,
                AuthorFirstName = givenBook.AuthorFirstName,
                AuthorLastName = givenBook.AuthorLastName
            };
        }

        public BookDetailsDTO BookToDetailsDTO(Book givenBook)
        {
            return new BookDetailsDTO
            {
                Isbn = givenBook.Isbn,
                Title = givenBook.Title,
                FirstNameAuthor = givenBook.AuthorFirstName,
                LastNameAuthor = givenBook.AuthorLastName
            };
        }

        public Book BookDTOToBook(BookDTO bookDTO)
        {
            throw new NotImplementedException();
        }
    }
}
