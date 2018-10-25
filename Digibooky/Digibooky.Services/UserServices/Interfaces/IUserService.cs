using Digibooky.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Services.UserServices.Interfaces
{
    public interface IUserService
    {
        void Register(User user);
        List<User> GetAllUsers();
    }
}
