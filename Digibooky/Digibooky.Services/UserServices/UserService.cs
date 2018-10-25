using System;
using System.Collections.Generic;
using System.Text;
using Digibooky.Databases;
using Digibooky.Domain.Users;
using Digibooky.Services.UserServices.Interfaces;

namespace Digibooky.Services.UserServices
{
    public class UserService : IUserService
    {
        public void Register(User user)
        {
            UsersDatabase.users.Add(user);
        }
    }
}
