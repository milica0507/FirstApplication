using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Models
{
    public class Product
    {
        public Product()
        {
            ProductId = Guid.NewGuid().ToString();
        }
        public string ProductId { get; set; }
        public string Name{get; set; }
        public double Price { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
   
}
