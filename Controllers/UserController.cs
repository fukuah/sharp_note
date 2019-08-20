using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpNote.ApiResponseHelpers;
using SharpNote.Services;
using SharpNote.Models;

namespace SharpNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        /// <summary>
        /// Gets user information by username.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <returns>UserInfo object.</returns>
        [HttpGet("{username}")]
        public ApiResponse GetByUsername(string username)
        {
            var info = _userService.GetByUsername(username);
            return new ApiResponse<UserInfo>(info.ToModel());
        }

        [HttpPost("login")]
        public ApiResponse Login([FromBody] LoginForm form)
        {
            return new ApiResponse<string>(_userService.GetToken(form));
        }

        [HttpPost("register")]
        public ApiResponse Register([FromBody] RegistrationForm form)
        {
            _userService.Register(form);

            return new ApiResponse();
        }
    }
}