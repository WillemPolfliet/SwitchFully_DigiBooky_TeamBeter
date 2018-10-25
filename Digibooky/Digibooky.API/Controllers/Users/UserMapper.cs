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

            var user = UserBuilder.CreateUser()
                .WithINSS(userDTORegister.INSS)
                .WithFirstName(userDTORegister.FirstName)
                .WithLastName(userDTORegister.LastName)
                .WithEmail(userDTORegister.Email)
                .WithPassword(userDTORegister.Password)
                .WithStreet(userDTORegister.Street)
                .WithStreetNumber(userDTORegister.StreetNumber)
                .WithPostalCode(userDTORegister.PostalCode)
                .WithCity(userDTORegister.City)
                .Build();
                
            return user;
        }
    }
}
