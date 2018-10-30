using Digibooky.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Digibooky.Services.UserServices.Interfaces
{
    public interface IUserService
    {
        void Register(@string user);
        List<@string> GetAllUsers();
        void UpdateInformation(@string.Roles newRole, long userINSS);
        Task<@string> Authenticate(string username, string password);
    }
}
