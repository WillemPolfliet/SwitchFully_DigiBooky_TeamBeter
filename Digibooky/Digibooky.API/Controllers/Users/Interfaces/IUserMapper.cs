using Digibooky.Domain.Users;
using Microsoft.AspNetCore.Mvc;
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
        List<UserDTO> ListofUserToDTOList(List<User> list);
    }
}
