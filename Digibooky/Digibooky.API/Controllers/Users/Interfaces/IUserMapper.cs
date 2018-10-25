using Digibooky.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Users.Interfaces
{
    public interface IUserMapper
    {
        User DTORegisterToUser(UserDTORegister userDTORegister);
        UserDTO UserToDTO(User user);
    }
}
