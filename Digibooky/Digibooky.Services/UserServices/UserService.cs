using Digibooky.Databases;
using Digibooky.Domain.Users;
using Digibooky.Domain.Users.Exceptions;
using Digibooky.Services.UserServices.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.Services.UserServices
{
    public class UserService : IUserService
    {
		private readonly ILogger<UserService> _logger;

		public UserService(ILogger<UserService> logger)
		{
			_logger = logger;
		}

		public async Task<@string> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => UsersDatabase.users.SingleOrDefault(userToLogin => userToLogin.Email == username && userToLogin.Password == password));

            if (user == null)
            {
				_logger.LogError(Guid.NewGuid() + $" User not found: (username: {username}");

				return null;
            }

            return user;
        }

        public List<@string> GetAllUsers()
        {
            return UsersDatabase.users;
        }

        public void Register(@string user)
        {
            var doesINSSExist = UsersDatabase.users.Any(dbUser => dbUser.INSS == user.INSS);
            var doesEmailExist = UsersDatabase.users.Any(dbUser => dbUser.Email == user.Email);

            if (doesINSSExist)
            {
				_logger.LogError(Guid.NewGuid() + $" INSS already exists: {user.INSS}");
				throw new UserException("INSS already exists");
            }

            if (doesEmailExist)
            {
				_logger.LogError(Guid.NewGuid() + $" Email already exists: {user.Email}");
				throw new UserException("Email already exists");
            }

            UsersDatabase.users.Add(user);
        }

        public void UpdateInformation(@string.Roles userRole, long userINSS)
        {
            var doesUserExist = UsersDatabase.users.Any(dbUser => dbUser.INSS == userINSS);

            if (doesUserExist)
            {
				UsersDatabase.users.First(dbUser => dbUser.INSS == userINSS)
					.SetRole(userRole);
            }
            else
            {
				_logger.LogError(Guid.NewGuid() + $" User not found: (username: {userINSS}");
				throw new UserException("This user does not exist in our database");
            }
        }
    }
}
