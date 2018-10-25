using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digibooky.Domain.Users;
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

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register([FromBody] User userToRegister)
        {
            _userService.Register(userToRegister);
            return Ok();
        }
    }
}