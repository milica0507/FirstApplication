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
    
    public class ProductsController : Controller
    {
        private ProductsService _productsService;
        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct([FromBody] ProductVM product)
        {
            _productsService.AddProduct(product);
            return Ok(product);
        }
        //private readonly ApplicationDbContext _context;

        //public ProductsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        //[HttpGet]
        //[Route("GetProducts")]
        //public async Task<IActionResult> Index()
        //{
        //    var listOfProducts = await _context.Products.ToListAsync();

        //    return Ok(listOfProducts);
        //}





        //[HttpPost]
        //[Route("CreateProduct")]
        //public async Task<IActionResult> Create([FromBody] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(product);
        //        await _context.SaveChangesAsync();
        //       // return RedirectToAction(nameof(Index));
        //    }
        //    return Ok(product);
        //}


        //[HttpPut]
        //[Route("EditProduct/{id}/{newPrice}")]
        //public async Task<IActionResult> Edit(string id,int newPrice)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    product.Price = newPrice;
        //    await _context.SaveChangesAsync();
        //    return Ok("Succesfully chnaged price of product");      
        //}






        //[HttpDelete]
        //[Route("DeleteConfirmed/{id}")]

        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return Ok("Deleted");
        //}


    }
}
