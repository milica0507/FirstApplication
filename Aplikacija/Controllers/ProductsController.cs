using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplikacija;
using Aplikacija.Models;
using Aplikacija.Services;
using Aplikacija.ViewModels;

namespace Aplikacija.Controllers
{
    [Route("api/product")]
    public class ProductsController : Controller
    {
        private ProductsService _productsService;
        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] ProductVM _product)
        {
            _productsService.AddProduct(_product);
            return Ok(_product);
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            var products=_productsService.GetAllProducts();
            return Ok(products);
        }
       

    }
}
