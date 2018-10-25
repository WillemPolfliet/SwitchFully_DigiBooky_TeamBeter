using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Digibooky.Services.UserServices;
using Digibooky.Domain.Users;
using Digibooky.Databases;
using System.Linq;

namespace Digibooky.Services.Tests.UserServices
{
    public class UserServiceTests
    {
        [Fact]
        public void GivenUserDatabaseAndAUser_WhenRegister_ThenUserIsAddedToDatabase()
        {
            var user = new User(1234567891234, "Firstname", "Lastname", "user@user.com", "password", User.Roles.member, "Street", "5A", 2800, "Mechelen");

            UserService userService = new UserService();

            userService.Register(user);

            var actual = UsersDatabase.users.Any(userSearch => userSearch.INSS == 1234567891234);

            Assert.True(actual);
        }

        [Fact]
        public void GivenUserDataBase_WhenGetAll_ThenAllUsersAreReturned()
        {
            UserService userService = new UserService();

            var actual = userService.GetAll();

            Assert.IsType<List<User>>(actual);
        }


    }
}
