using Digibooky.API.Controllers.Users.Interfaces;
using Digibooky.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Digibooky.Domain.Users.User;

namespace Digibooky.API.Controllers.Users
{
    public class UserMapper : IUserMapper
    {
        public User DTORegisterToUser(UserDTORegister userDTORegister)
        {
            var userRole = (Roles)Enum.Parse(typeof(Roles), userDTORegister.UserRole);

            var user = new User(userDTORegister.INSS, userDTORegister.FirstName, userDTORegister.LastName,
                userDTORegister.Email,
                userDTORegister.Password, userRole, userDTORegister.Street,
                userDTORegister.StreetNumber, userDTORegister.PostalCode, userDTORegister.City);

            return user;
        }
    }
}
