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
            //TO ASK: DO SAME AS BELOW?
            AuthorMapper authorMapper = new AuthorMapper();

            return new BookDTO
            {
                Isbn = givenBook.Isbn,
                Title = givenBook.Title,
                AuthorDTO = authorMapper.AuthorToDTO(givenBook.Author)
            };
        }

        public BookDetailsDTO BookToDetailsDTO(Book givenBook)
        {
            return new BookDetailsDTO
            {
                Isbn = givenBook.Isbn,
                Title = givenBook.Title,
                IDAuthor = givenBook.Author.AuthorId,
                FirstNameAuthor = givenBook.Author.FirstName,
                LastNameAuthor = givenBook.Author.LastName
            };
        }
    }
}
