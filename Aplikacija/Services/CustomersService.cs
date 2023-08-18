using Aplikacija.Models;
using Aplikacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Services
{
    public class CustomersService
    {

        private ApplicationDbContext _context;
        public CustomersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(CustomerVM customer)
        {
            var _customer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
            _context.Customers.Add(_customer);
            _context.SaveChanges();

          
        }
    }
}
