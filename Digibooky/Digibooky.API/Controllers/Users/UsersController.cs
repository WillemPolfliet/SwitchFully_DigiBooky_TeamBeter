﻿using Digibooky.API.Controllers.Users.Interfaces;
using Digibooky.Domain.Users;
using Digibooky.Domain.Users.Exceptions;
using Digibooky.Services.UserServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            return Ok(_userMapper.ListofUserToDTOList(_userService.GetAllUsers()));
        }

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
                return BadRequest(userEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}