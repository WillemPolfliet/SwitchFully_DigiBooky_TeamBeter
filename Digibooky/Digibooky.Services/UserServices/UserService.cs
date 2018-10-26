using Digibooky.Databases;
using Digibooky.Domain.Users;
using Digibooky.Domain.Users.Exceptions;
using Digibooky.Services.UserServices.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.Services.UserServices
{
    public class UserService : IUserService
    {
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => UsersDatabase.users.SingleOrDefault(userToLogin => userToLogin.Email == username && userToLogin.Password == password));

            if (user == null)
            {
                return null;
            }

            return user;
        }

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

        public void RegisterAsLibrarian(long userINSS)
        {
            var doesUserExist = UsersDatabase.users.Any(dbUser => dbUser.INSS == userINSS);

            if (doesUserExist)
            {
                UsersDatabase.users.First(dbUser => dbUser.INSS == userINSS)
                    .UserRoles.Add(User.Roles.librarian);
            }
            else
            {
                throw new UserException("This user does not exist in our database");
            }
        }
    }
}
