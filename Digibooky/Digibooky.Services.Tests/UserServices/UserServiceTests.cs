﻿using Digibooky.Databases;
using Digibooky.Domain.Users;
using Digibooky.Domain.Users.Exceptions;
using Digibooky.Services.UserServices;
using Digibooky.Services.UserServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Digibooky.Services.Tests.UserServices
{
    public class UserServiceTests
    {
		private readonly IUserService _userService;

		public UserServiceTests(IUserService userService)
		{
			_userService = userService;
		}

		[Fact]
        public void GivenUserDatabaseAndAUser_WhenRegister_ThenUserIsAddedToDatabase()
        {
            var user = UserBuilder.CreateUser()
                .WithINSS(1234567891235)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithEmail("user01@user.com")
                .WithPassword("Password123")
                .WithRole()
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            //IUserService userService = new UserService();

            _userService.Register(user);

            var actual = UsersDatabase.users.Any(userSearch => userSearch.INSS == 1234567891234);

            Assert.True(actual);
        }

        [Fact]
        public void GivenUserDataBase_WhenGetAll_ThenAllUsersAreReturned()
        {
            //IUserService userService = new UserService();

            var actual = _userService.GetAllUsers();

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
                .WithRole()
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            //IUserService userService = new UserService();

            Action act = () => _userService.Register(user);

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
                .WithRole()
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            //IUserService userService = new UserService();

            Action act = () => _userService.Register(user);

            var exception = Assert.Throws<UserException>(act);

            Assert.Equal("Email already exists", exception.Message);

        }

        [Fact]
        public void GivenUserToRegisterAsLibrarian_RegisteringTheUser_UserHasLibrarianAsRole()
        {
            //IUserService userService = new UserService();
            var user = UsersDatabase.users[0];
            _userService.UpdateInformation(User.Roles.librarian, user.INSS);

            var rolesActual = UsersDatabase.users.FirstOrDefault(usr => usr.ID == user.ID).UserRoles;
            var rolesExpected = User.Roles.librarian;

            Assert.Equal(rolesExpected, rolesActual);
        }

        [Fact]
        public async void WhenUsergiven_AuthenticatingMember_ThenMemberLogsIn()
        {
            //IUserService userService = new UserService();

            var actual = await _userService.Authenticate(UsersDatabase.users[0].Email, UsersDatabase.users[0].Password);

            Assert.Equal(actual, UsersDatabase.users[0]);
        }
    }
}
