﻿using System;
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
        private readonly IAuthService _authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
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
            return new ApiResponse<UserInfoModel>(info.ToModel());
        }

        [HttpPost("login")]
        public ApiResponse Login([FromBody] LoginForm form)
        {
           if (_userService.UserExists(form))
            {
                return new ApiResponse<string>(_authService.GenerateToken(form.Username));
            }
            return new ApiResponse<string>("", new ApiError(new UnauthorizedAccessException()));
        }

        [HttpPost("register")]
        public ApiResponse Register([FromBody] RegistrationForm form)
        {
            _userService.Register(form);

            return new ApiResponse();
        }
    }
}