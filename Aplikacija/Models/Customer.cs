using System;
using System.Collections.Generic;

namespace Aplikacija.Models
{
    public class Customer
    {
        public Customer()
        {
            CustomerId = Guid.NewGuid().ToString();
        }
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Product> Products  { get; set; }

    }
}
