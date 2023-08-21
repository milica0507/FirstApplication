﻿using Aplikacija.Models;
using Aplikacija.Services;
using Aplikacija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Controllers
{
    [Route("api/author")]
    public class AuthController : Controller
    {
        private UsersService _usersService;

        public AuthController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserVM user)
        {
            try
            {
                _usersService.RegisterUser(user);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] UserVM user)
        {
            try
            {
                string token=_usersService.LogIn(user);
                return new ContentResult
                {
                    ContentType = "text/plain",
                    StatusCode = 200,
                    Content = token
                };
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        
    }
}
