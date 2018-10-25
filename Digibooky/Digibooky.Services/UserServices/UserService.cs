using System;
using System.Collections.Generic;
using System.Text;
using Digibooky.Databases;
using Digibooky.Domain.Users;

namespace Digibooky.Services.UserServices
{
    public class UserService
    {
        public void Register(User user)
        {
            UsersDatabase.users.Add(user);
        }
    }
}
