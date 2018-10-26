using Digibooky.Databases;
using Digibooky.Domain.Authors;
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
		private readonly IBookService bookservice;

		public BookServiceTests(IBookService bookservice)
		{
			this.bookservice = bookservice;
		}

		public static void Initialize()
		{
			BooksDatabase.booksDb.Clear();

			var temp = new List<Book>()
				{
					new Book("9789024555147", "Het Franciscus Verbond", new Author(1, "John", "Sack")),
					new Book("9789028418028", "Wereldbibliotheekreeks Verloren eer", new Author(2, "Calixthe", "Beyala")),
					new Book("9789021006536", "Drie weken in Parijs", new Author(3, "Barbara", "Bradford Taylor")),
					new Book("9789063050184", "Icy Sparks", new Author(4, "Gwyn", "Hyman Rubio"))
				};

			BooksDatabase.booksDb.AddRange(temp);
		}

		[Fact]
		public void GivenAListOfBooks_WhenGetAllBooks_AllBooksAreReturned()
		{
			Initialize();

			BookService bookservice = new BookService();


			var actual = bookservice.GetAllBooks();


			Assert.Equal(BooksDatabase.booksDb.Count, actual.Count);
		}

		[Fact]
		public void GivenBookDatabase_WhenGetBookByISBNWithCorrectISBN_ThenReturnBook()
		{
			Initialize();

			BookService bookService = new BookService();

			var actual = bookService.GetBookByISBN("9789024555147");

			Assert.Equal(BooksDatabase.booksDb[0], actual);
		}

		[Fact]
		public void GivenBookDatabase_WhenGetBookByISBNWithWrongISBN_ThenThrowException()
		{
			Initialize();

			BookService bookService = new BookService();

			var exception = Assert.Throws<BookException>(() => bookService.GetBookByISBN("1234563"));

			Assert.Equal("This ISBN can not be found", exception.Message);
		}
	}
}
