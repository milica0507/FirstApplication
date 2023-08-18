using Aplikacija.Models;
using Aplikacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Services
{
    public class ProductsService
    {
        private ApplicationDbContext _context;
        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProduct(ProductVM product)
        {
            var _product = new Product()
            {
                Name=product.Name,
                Price=product.Price
            };
            _context.Products.Add(_product);
            _context.SaveChanges();
        }
    }
}
