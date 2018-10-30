using Digibooky.API.Controllers.Users.Interfaces;
using Digibooky.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using static Digibooky.Domain.Users.@string;

namespace Digibooky.API.Controllers.Users
{
    public class UserMapper : IUserMapper
    {
        public @string DTORegisterToUser(UserDTORegister userDTORegister)
        {
            var user = UserBuilder.CreateUser()
                .WithINSS(userDTORegister.INSS)
                .WithFirstName(userDTORegister.FirstName)
                .WithLastName(userDTORegister.LastName)
                .WithEmail(userDTORegister.Email)
                .WithRole()
                .WithPassword(userDTORegister.Password)
                .WithStreet(userDTORegister.Street)
                .WithStreetNumber(userDTORegister.StreetNumber)
                .WithPostalCode(userDTORegister.PostalCode)
                .WithCity(userDTORegister.City)
                .Build();

            return user;
        }

        public List<UserDTO> ListofUserToDTOList(List<@string> givenListOfUsers)
        {
            var dtoList = new List<UserDTO>();

            foreach (var user in givenListOfUsers)
            {
                dtoList.Add(UserToDTO(user));
            }

            return dtoList;
        }

        public UserDTO UserToDTO(@string user)
        {
			return new UserDTO
			{
				INSS = user.INSS,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				Password = user.Password,
				UserRole = user.UserRoles.ToString(),
                Street = user.Street,
                StreetNumber = user.StreetNumber,
                PostalCode = user.PostalCode,
                City = user.City
            };
        }

        private string PrintAsString(List<Roles> userRoles)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var role in userRoles)
            {
                sb.Append(role.ToString());
                sb.Append(", ");
            }

            return sb.ToString();
        }
    }
}
