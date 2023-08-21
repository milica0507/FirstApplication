using Aplikacija.Models;
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

        [HttpPost("login/{username}/{pass}")]
        public IActionResult LogIn(string username,string pass)
        {
            try
            {
                string token=_usersService.LogIn(username,pass);
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

        [HttpPost("logout/{id}")]
        public IActionResult LogOut(string id)
        {
            try
            {
                _usersService.LogOut(id);
                return Ok("Log out");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete("delete-user/{userId}")]
        public IActionResult DeleteUser(string userId)
        {
            try
            {
                _usersService.DeleteUser(userId);
                return Ok("Deleted user");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpPut("change-username/{idUser}")]
        public IActionResult ChangeUsername(string idUser,string newUsername)
        {
            try
            {
                var user= _usersService.UpdateUsername(idUser, newUsername);
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-by-username/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            try
            {
                var user = _usersService.GetUserByUsername(username);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
