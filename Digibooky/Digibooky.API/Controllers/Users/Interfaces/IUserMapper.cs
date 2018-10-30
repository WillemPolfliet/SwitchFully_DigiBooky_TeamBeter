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
        @string DTORegisterToUser(UserDTORegister userDTORegister);
        UserDTO UserToDTO(@string user);
        List<UserDTO> ListofUserToDTOList(List<@string> list);
    }
}
