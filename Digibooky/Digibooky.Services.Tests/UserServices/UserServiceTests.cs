using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Digibooky.Services.UserServices;
using Digibooky.Domain.Users;
using Digibooky.Databases;
using System.Linq;
using Digibooky.Domain.Users.Exceptions;

namespace Digibooky.Services.Tests.UserServices
{
    public class UserServiceTests
    {
        [Fact]
        public void GivenUserDatabaseAndAUser_WhenRegister_ThenUserIsAddedToDatabase()
        {
            var user = UserBuilder.CreateUser()
                .WithINSS(1234567891235)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithEmail("user01@user.com")
                .WithPassword("Password123")
                .WithRole(User.Roles.member)
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            UserService userService = new UserService();

            userService.Register(user);

            var actual = UsersDatabase.users.Any(userSearch => userSearch.INSS == 1234567891234);

            Assert.True(actual);
        }

        [Fact]
        public void GivenUserDataBase_WhenGetAll_ThenAllUsersAreReturned()
        {
            UserService userService = new UserService();

            var actual = userService.GetAllUsers();

            Assert.IsType<List<User>>(actual);
        }

        [Fact]
        public void GivenUserDatabaseAndUser_WhenAddingUserWithExistingINSS_ThenThrowException()
        {
            var user = UserBuilder.CreateUser()
                .WithINSS(1234567891234)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithEmail("user@user.com")
                .WithPassword("Password123")
                .WithRole(User.Roles.member)
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            UserService userService = new UserService();

            Action act = () => userService.Register(user);

            var exception = Assert.Throws<UserException>(act);

            Assert.Equal("INSS already exists", exception.Message);

        }

        [Fact]
        public void GivenUserDatabaseAndUser_WhenAddingUserWithExistingEmail_ThenThrowException()
        {
            var user = UserBuilder.CreateUser()
                .WithINSS(1234567891236)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithEmail("user@user.com")
                .WithPassword("Password123")
                .WithRole(User.Roles.member)
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            UserService userService = new UserService();

            Action act = () => userService.Register(user);

            var exception = Assert.Throws<UserException>(act);

            Assert.Equal("Email already exists", exception.Message);

        }


    }
}
