using Digibooky.Databases;
using Digibooky.Domain.Lendings;
using Digibooky.Domain.Lendings.Exceptions;
using Digibooky.Services.DatabaseServices;
using Digibooky.Services.LendingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Digibooky.Services.Tests.LendingServices
{
    public class LendingServiceTests
    {
        [Fact]
        public void GivenCountBeforeLending_WhenLendBook_ThenCountAfterLendingIsPlusOne()
        {
            BooksDatabase.booksDb.Add(new Domain.Books.Book("1231231231231", "title", new Domain.Authors.Author(0)));
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
            BooksDatabase.booksDb.Add(new Domain.Books.Book("1231231231231", "title", new Domain.Authors.Author(0)));

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
            BooksDatabase.booksDb.Add(new Domain.Books.Book("1231231231231", "title", new Domain.Authors.Author(0)));

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
            BooksDatabase.booksDb.Add(new Domain.Books.Book("1417258369", "titlev2", new Domain.Authors.Author(0)));

            //when
            LendingService lendingService = new LendingService();
            lendingService.LendBook(1234567891234, "1417258369");
            Action act = () => lendingService.LendBook(1234567891234, "1417258369");

            //then
            var exception = Assert.Throws<LentOutException>(act);
            Assert.Equal("Book is currently not available, it is already lent out.", exception.Message);
        }



        [Fact]
        public void GivenALedingDatabaseWithLendingBooks_WhenReturningABook_TheBookDateReturnedIsFilledIn()
        {

            LendingsDatabase.Lendings.Add(new Lending(1234567891234, "isbn"));
            var lendingTest = LendingsDatabase.Lendings.FirstOrDefault(lend => lend.Isbn == "isbn");

            LendingService lendingService = new LendingService();
            lendingService.ReturnBook(lendingTest.ID.ToString());

            var lendingTestReturned = LendingsDatabase.Lendings.FirstOrDefault(lend => lend.Isbn == "isbn");
            Assert.Equal(lendingTestReturned.DateReturned, DateTime.Now.Date);
        }
        [Fact]
        public void GivenALedingDatabaseWithLendingBooks_WhenReturningABookThatIsOverDue_TheBookDateReturnedIsFilledInAndAnExceprtionIsThrown()
        {

            LendingsDatabase.Lendings.Add(new Lending(1234567891234, "isbnv2"));
            var lendingTest = LendingsDatabase.Lendings.FirstOrDefault(lend => lend.Isbn == "isbnv2");

            lendingTest.ReturnDate = DateTime.Now.Date.AddDays(-1);

            LendingService lendingService = new LendingService();


            Action act = () => lendingService.ReturnBook(lendingTest.ID.ToString());

            var exception = Assert.Throws<LentOutException>(act);
            Assert.Equal("Lend is overdue", exception.Message);
        }

        [Fact]
        public void GivenALedingDatabaseWithLendingBooks_WhenReturningABookThatIsNotLend_AnExceptionIsThrown()
        {

            LendingService lendingService = new LendingService();



            Action act = () => lendingService.ReturnBook("123456");

            var exception = Assert.Throws<LendingException>(act);

            Assert.Equal("Lend does not excist", exception.Message);
        }



    }
}
