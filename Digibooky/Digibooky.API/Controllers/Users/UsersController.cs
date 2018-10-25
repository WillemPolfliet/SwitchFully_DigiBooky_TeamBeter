using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digibooky.API.Controllers.Users.Interfaces;
using Digibooky.Domain.Users;
using Digibooky.Domain.Users.Exceptions;
using Digibooky.Services.UserServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digibooky.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserMapper _userMapper;

        public UsersController(IUserService userService, IUserMapper userMapper)
        {
            _userService = userService;
            _userMapper = userMapper;
        }

        [HttpPost]
        public ActionResult<User> Register([FromBody]UserDTORegister userToRegister)
        {
            try
            {
            _userService.Register(_userMapper.DTORegisterToUser(userToRegister));
            return Ok();
            }
            catch (UserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetAll()
        {
            var dtoList = new List<UserDTO>();
            foreach (var user in _userService.GetAll())
            {
                dtoList.Add(_userMapper.UserToDTO(user));
            }
            return dtoList;
        }
    }
}