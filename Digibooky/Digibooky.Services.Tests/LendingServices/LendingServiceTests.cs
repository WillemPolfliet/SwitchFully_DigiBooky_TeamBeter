using Digibooky.Databases;
using Digibooky.Domain.Lendings;
using Digibooky.Services.DatabaseServices;
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
    }
}
