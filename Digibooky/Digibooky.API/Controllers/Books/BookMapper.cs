using Digibooky.API.Controllers.Books.Interfaces;
using Digibooky.Databases;
using Digibooky.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Book BookDTORegisterToBook(BookDTORegister bookDTORegister)
        {
            return new Book(bookDTORegister.Isbn, bookDTORegister.Title, bookDTORegister.AuthorFirstName, bookDTORegister.AuthorLastName);
        }

        public List<OverdueBookDTO> ListOfOverdueBookToDTOList(List<OverdueBook> overdueBookList)
        {
            var overdueBookListDTO = new List<OverdueBookDTO>();

            foreach (var overdueBook in overdueBookList)
            {
                OverdueBookDTO overdueBookDTO = new OverdueBookDTO(
                    overdueBook.BookId,
                    overdueBook.Isbn,
                    overdueBook.Title,
                    overdueBook.LendingID,
                    overdueBook.INSS,
                    overdueBook.Date,
                    overdueBook.ReturnDate,
                    overdueBook.DateReturned,
                    overdueBook.userEmail
                    );

                overdueBookListDTO.Add(overdueBookDTO);
            }

            return overdueBookListDTO;
        }

    }
}
