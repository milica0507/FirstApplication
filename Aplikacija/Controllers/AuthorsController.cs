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
    public class AuthorsController : Controller
    {
        private AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }


        [HttpPost]
        [Route("AddAuthor")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok(author);
        }

        [HttpGet]
        [Route("GetAuthorWithBooksById/{id}")]
        public IActionResult GetAuthorWithBooksById(string id)
        {
            try
            {
                var author = _authorsService.GetAuthorWithBooks(id);
                return Ok(author);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
