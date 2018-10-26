using Digibooky.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Digibooky.Services.UserServices.Interfaces
{
    public interface IUserService
    {
        void Register(User user);
        List<User> GetAllUsers();
        void UpdateInformation(User.Roles newRole, long userINSS);
        Task<User> Authenticate(string username, string password);
    }
}
