using Digibooky.API.Controllers.Users.Interfaces;
using Digibooky.Domain.Users;
using Digibooky.Domain.Users.Exceptions;
using Digibooky.Services.UserServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Digibooky.API.Controllers.Users
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserMapper _userMapper;
		private readonly ILogger<UsersController> _logger;

		public UsersController(IUserService userService, IUserMapper userMapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _userMapper = userMapper;
			_logger = logger;
        }

        public object UserDatabase { get; private set; }

        [Authorize(Policy = "MustBeAdmin")]
        [HttpGet]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
			_logger.LogInformation("Get all users");
            return Ok(_userMapper.ListofUserToDTOList(_userService.GetAllUsers()));
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<User> Register([FromBody]UserDTORegister userToRegister)
        {
            try
            {
                _userService.Register(_userMapper.DTORegisterToUser(userToRegister));
                return Ok();
            }
            catch (UserException userEx)
            {
				_logger.LogError(Guid.NewGuid() + userEx.Message);
                return BadRequest(userEx.Message);
            }
            catch (Exception ex)
            {
				_logger.LogError(Guid.NewGuid() + ex.Message);

				return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "MustBeAdmin")]
        [HttpPut]
        [Route("{INSS}")]
        public ActionResult<User> UpdateUserDetails([FromQuery]User.Roles newRole, [FromRoute] long INSS)
        {
            try
            {
                _userService.UpdateInformation(newRole, INSS);
                return Ok();
            }
            catch (UserException userEx)
            {
				_logger.LogError(Guid.NewGuid() + userEx.Message);

				return BadRequest(userEx.Message);
            }
            catch (Exception ex)
            {
				_logger.LogError(Guid.NewGuid() + ex.Message);

				return BadRequest(ex.Message);
            }
        }
    }

}
