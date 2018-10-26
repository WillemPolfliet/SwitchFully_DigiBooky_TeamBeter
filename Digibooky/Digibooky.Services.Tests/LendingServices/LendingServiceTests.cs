using Digibooky.Databases;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Digibooky.Services.LendingServices;
using Digibooky.Services.DatabaseServices;

namespace Digibooky.Services.Tests.LendingServices
{
    public class LendingServiceTests
    {
        [Fact]
        public void GivenCountBeforeLending_WhenLendBook_ThenCountAfterLendingIsPlusOne()
        {
            DatabaseService.InitializeDatabase();

            Guid userId = UsersDatabase.users[0].ID;
            Guid bookId = BooksDatabase.booksDb[0].Id;

            int countBeforeLending = LendingsDatabase.Lendings.Count;

            LendingService lendingService = new LendingService();

            lendingService.LendBook(userId, bookId);

            int countAfterLending = LendingsDatabase.Lendings.Count;

            Assert.Equal(countAfterLending, countBeforeLending + 1);
        }
    }
}
