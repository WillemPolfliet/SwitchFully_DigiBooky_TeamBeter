using Digibooky.Domain.Books;
using Digibooky.Domain.Books.Exceptions;
using Xunit;

namespace Digibooky.Domain.Tests.BookTests
{
    public class BookTests
    {
        [Fact]
        public void GivenBookParameters_WhenCreateBookWithWrongISBNWithLetters_ThenThrowBookException()
        {
            var exception = Assert.Throws<BookException>(() => new Book("blablbal", "Het Franciscus Verbond", "John", "Sack"));

            Assert.Equal("This ISBN contains a non-digit", exception.Message);
        }

        [Fact]
        public void GivenBookParameters_WhenCreateBookWithWrongISBNWithNot13Numbers_ThenThrowBookException()
        {
            var exception = Assert.Throws<BookException>(() => new Book("123456789", "Het Franciscus Verbond", "John", "Sack"));

            Assert.Equal("The ISBN must contain 13 digits", exception.Message);
        }

        [Fact]
        public void GivenBookParameters_WhenCreateBookWithEmptyTitle_ThenThrowBookException()
        {
            var exception = Assert.Throws<BookException>(() => new Book("1234567890123", "", "John", "Sack"));

            Assert.Equal("The title is required", exception.Message);
        }

        [Fact]
        public void GivenBookParameters_WhenCreateBookWithWhitespaceTitle_ThenThrowBookException()
        {
            var exception = Assert.Throws<BookException>(() => new Book("1234567890123", "  ", "John", "Sack"));

            Assert.Equal("The title is required", exception.Message);
        }
    }
}
