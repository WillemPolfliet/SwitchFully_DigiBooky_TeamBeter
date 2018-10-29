using Digibooky.Databases;
using Digibooky.Domain.Books;
using Digibooky.Domain.Books.Exceptions;
using Digibooky.Services.BookServices;
using Digibooky.Services.BookServices.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace Digibooky.Services.Tests.BookServices
{
    public class BookServiceTests
    {
        IBookService bookService;

        public BookServiceTests()
        {
            BooksDatabase.booksDb.Clear();

            var temp = new List<Book>()
                {
                    new Book("9789024555147", "Het Franciscus Verbond",  "John", "Sack"),
					new Book("9789028418028", "Wereldbibliotheekreeks Verloren eer", "Calixthe", "Beyala"),
					new Book("9789021006536", "Drie weken in Parijs", "Barbara", "Bradford Taylor"),
					new Book("9789063050184", "Icy Sparks", "Gwyn", "Hyman Rubio")
				};

        BooksDatabase.booksDb.AddRange(temp);

            this.bookService = new BookService();
    }

    [Fact]
    public void GivenAListOfBooks_WhenGetAllBooks_AllBooksAreReturned()
    {

        var actual = bookService.GetAllBooks();

        Assert.Equal(BooksDatabase.booksDb.Count, actual.Count);
    }

    [Fact]
    public void GivenBookDatabase_WhenGetBookByISBNWithCorrectISBN_ThenReturnBook()
    {
        var actual = bookService.GetBookByISBN("9789024555147");

        Assert.Equal(BooksDatabase.booksDb[0], actual);
    }

    [Fact]
    public void GivenBookDatabase_WhenGetBookByISBNWithWrongISBN_ThenThrowException()
    {
        var exception = Assert.Throws<BookException>(() => bookService.GetBookByISBN("1234563"));

        Assert.Equal("This ISBN can not be found", exception.Message);
    }

    [Fact]
    public void GivenBookDatabase_WhenRegisterBook_ThenBookAddedToDatabase()
    {
        Book bookToRegister = new Book("9789024555147", "Het Franciscus Verbond", "John", "Sack");

        bookService.Register(bookToRegister);

        var actual = BooksDatabase.booksDb.Count;

        Assert.Equal(5, actual);
    }
}
}
