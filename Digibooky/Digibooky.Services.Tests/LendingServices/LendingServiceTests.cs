using Digibooky.Databases;
using Digibooky.Domain.Lendings;
using Digibooky.Domain.Lendings.Exceptions;
using Digibooky.Services.LendingServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Digibooky.Services.Tests.LendingServices
{
    public class LendingServiceTests
    {
        [Fact]
        public void GivenCountBeforeLending_WhenLendBook_ThenCountAfterLendingIsPlusOne()
        {
            BooksDatabase.booksDb.Add(new Domain.Books.Book("1231231231231", "title", "G","J"));
            long inss = UsersDatabase.users[0].INSS;
            string isbn = BooksDatabase.booksDb[0].Isbn;
            int countBeforeLending = LendingsDatabase.Lendings.Count;

            LendingService lendingService = new LendingService();
            lendingService.LendBook(inss, isbn);

            int countAfterLending = LendingsDatabase.Lendings.Count;
            Assert.Equal(countAfterLending, countBeforeLending + 1);
        }

        [Fact]
        public void GivenALendingService_WhenGetAll_ThenReceiveAListOfLendings()
        {
            LendingService lendingService = new LendingService();
            var actualResult = lendingService.GetAll();

            Assert.IsType<List<Lending>>(actualResult);
        }

		[Fact]
		public void GivenABooksDBAndAUserDB_WhenLendingABookWithNonExistingUserINSS_ThenGetException()
		{
			//Given
			BooksDatabase.booksDb.Add(new Domain.Books.Book("1231231231231", "title", "G", "J"));

			//When
			LendingService lendingService = new LendingService();
			Action act = () => lendingService.LendBook(123456, "1231231231231");

			//Then
			var exception = Assert.Throws<LendingException>(act);
			Assert.Equal("User INSS does not exist", exception.Message);
		}

		[Fact]
		public void GivenABooksDBAndAUserDB_WhenLendingABookWithNonExistingBookISBN_ThenGetException()
		{
			//Given
			BooksDatabase.booksDb.Add(new Domain.Books.Book("1231231231231", "title", "G", "J"));

			//When
			LendingService lendingService = new LendingService();
			Action act = () => lendingService.LendBook(1234567891234, "zertyui");

			//Then
			var exception = Assert.Throws<LendingException>(act);
			Assert.Equal("Book ISBN does not exist", exception.Message);
		}

        [Fact]
        public void GivenABooksDBAndAUserDB_WhenLendingABookThatIsInLendingDb_ThenGetException()
        {
            //given
			BooksDatabase.booksDb.Add(new Domain.Books.Book("1231231231231", "title", "G", "J"));

            //when
			LendingService lendingService = new LendingService();
			lendingService.LendBook(1234567891234, "1231231231231");
			Action act = () => lendingService.LendBook(1234567891234, "1231231231231");

            //then
			var exception = Assert.Throws<LentOutException>(act);
			Assert.Equal("Book is currently not available, it is already lent out.", exception.Message);
        }

	}
}
