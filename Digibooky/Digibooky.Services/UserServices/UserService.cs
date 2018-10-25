using Digibooky.Databases;
using Digibooky.Domain.Users;
using Digibooky.Domain.Users.Exceptions;
using Digibooky.Services.UserServices.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Digibooky.Services.UserServices
{
    public class UserService : IUserService
    {
        public List<User> GetAllUsers()
        {
            return UsersDatabase.users;
        }

        public void Register(User user)
        {
            var doesINSSExist = UsersDatabase.users.Any(dbUser => dbUser.INSS == user.INSS);
            var doesEmailExist = UsersDatabase.users.Any(dbUser => dbUser.Email == user.Email);

            if (doesINSSExist)
            {
                throw new UserException("INSS already exists");
            }

            if (doesEmailExist)
            {
                throw new UserException("Email already exists");
            }

            UsersDatabase.users.Add(user);
        }
    }
}
