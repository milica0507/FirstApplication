using Aplikacija.Models;
using Aplikacija.Services;
using Aplikacija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Controllers
{
    [Route("api/book")]
    public class BooksController : Controller
    {
        //private readonly ApplicationDbContext _context;
        public BooksService _booksService;


        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("create-book")]
        public IActionResult Create([FromBody] BookVM book)
        {


            _booksService.AddBook(book);
            return Ok(book);

        }

        [HttpGet("get-books")]
       public IActionResult Get()
        {
            var books=_booksService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(string id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook(string id,[FromBody] BookVM book)
        {
            var _book = _booksService.UpdateBookById(id,book);
            return Ok(_book);
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(string id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}

