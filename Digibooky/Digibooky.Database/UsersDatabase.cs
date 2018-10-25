using Digibooky.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Databases
{
    public static class UsersDatabase
    {
        public static List<User> users = new List<User>() { new User(123456789, "test", "test", "test", "test", User.Roles.member, "test", "test", 1, "test") };
    }
}
