using Digibooky.Databases;
using Digibooky.Databases.Books;
using Digibooky.Domain.Authors;
using Digibooky.Domain.Books;
using Digibooky.Services.BookServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Digibooky.Services.Tests.BookServices
{
    public class BookServiceTests
    {
        [Fact]
        public void GivenAListOfBooks_WhenGetAllBooks_AllBooksAreReturned()
        {
            var temp = new List<Book>()
                {
                    new Book("ISBN-152365214", "DefaultTitle", new Author(0, "DefaultName", "DefaultLastName")),
                    new Book("ISBN-152365214", "DefaultTitle", new Author(0, "DefaultName", "DefaultLastName")),
                    new Book("ISBN-152365214", "DefaultTitle", new Author(0, "DefaultName", "DefaultLastName")),
                    new Book("ISBN-152365214", "DefaultTitle", new Author(0, "DefaultName", "DefaultLastName"))
                };
            BooksDatabase.booksDb.AddRange(temp);
            BookService bookservice = new BookService();


            var actual = bookservice.GetAllBooks();


            Assert.Equal(BooksDatabase.booksDb.Count, actual.Count);
        }
    }
}
