using Digibooky.Domain.Users;
using System.Collections.Generic;

namespace Digibooky.Databases
{
    public static class UsersDatabase
    {
        public static List<User> users = new List<User>() { UserBuilder.CreateUser()
                .WithINSS(1234567891234)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithEmail("user@user.com")
                .WithPassword("Password123")
                .WithRole(User.Roles.admin)
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build() };
    };
}

