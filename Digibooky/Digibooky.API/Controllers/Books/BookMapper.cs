using Digibooky.API.Controllers.Books.Interfaces;
using Digibooky.Domain.Books;
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
                Isbn = givenBook.ISBN,
                Title = givenBook.Title,
                AuthorFirstName = givenBook.AuthorFirstName,
                AuthorLastName = givenBook.AuthorLastName
            };
        }

        public BookDTODetails BookToDetailsDTO(Dictionary<Book, string> givenBook)
        {
            BookDTODetails bookDTODetails = new BookDTODetails();
            foreach (var book in givenBook)
            {
                var bookIsLent = false;
                string lender = null;
                if (book.Value != null)
                {
                    bookIsLent = true;
                    lender = book.Value;
                }

                bookDTODetails.Isbn = book.Key.ISBN;
                bookDTODetails.Title = book.Key.Title;
                bookDTODetails.FirstNameAuthor = book.Key.AuthorFirstName;
                bookDTODetails.LastNameAuthor = book.Key.AuthorLastName;
                bookDTODetails.BookIsLent = bookIsLent;
                bookDTODetails.Lender = lender;
            }
            return bookDTODetails;
        }

        public Book BookDTORegisterToBook(BookDTORegister bookDTORegister)
        {
            return new Book(bookDTORegister.Isbn, bookDTORegister.Title, bookDTORegister.AuthorFirstName, bookDTORegister.AuthorLastName);
        }
    }
}
