using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Digibooky.Domain;
using Digibooky.Domain.Users;
using Digibooky.Domain.Users.Exceptions;

namespace Digibooky.Domain.Tests.UserTests
{
    public class UserTests
    {
        [Fact]
        public void GivenUserData_WhenCreatingUserWithWrongINSS_ThenThrowException()
        {
            Action act = () => UserBuilder.CreateUser()
                .WithINSS(123456789)
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

            var exception = Assert.Throws<UserException>(act);
            Assert.Equal("INSS must be 13 numbers", exception.Message);
        }

        [Fact]
        public void GivenUserData_WhenLastNameIsBlan_ThenThrowException()
        {
            Action act = () => UserBuilder.CreateUser()
                .WithINSS(1234567891234)
                .WithFirstName("Firstname")
                .WithLastName("")
                .WithEmail("user@user.com")
                .WithPassword("Password123")
                .WithRole(User.Roles.member)
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            var exception = Assert.Throws<UserException>(act);

            Assert.Equal("Last name is required", exception.Message);
        }

        [Fact]
        public void GivenUserDate_WhenEmailIsBlank_ThenThrowException()
        {
            Action act = () => UserBuilder.CreateUser()
                .WithINSS(1234567891234)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithEmail("")
                .WithPassword("Password123")
                .WithRole(User.Roles.member)
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            var exception = Assert.Throws<UserException>(act);

            Assert.Equal("Email is required", exception.Message);
        }

        [Fact]
        public void GivenUserData_WhenEmailIsWrongFormat_ThenThrowException()
        {
            Action act = () => UserBuilder.CreateUser()
                .WithINSS(1234567891234)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithEmail("thisisanemail")
                .WithPassword("Password123")
                .WithRole(User.Roles.member)
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            var exception = Assert.Throws<UserException>(act);

            Assert.Equal("Emailformat must be word@word.word", exception.Message);

        }

        [Fact]
        public void GivenUserDate_WhenCityIsBlank_ThenThrowException()
        {
            Action act = () => UserBuilder.CreateUser()
                .WithINSS(1234567891234)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithEmail("user@user.com")
                .WithPassword("Password123")
                .WithRole(User.Roles.member)
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("")
                .Build();

            var exception = Assert.Throws<UserException>(act);

            Assert.Equal("City is required", exception.Message);
        }
    }
}
