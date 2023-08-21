using Aplikacija.Models;
using Aplikacija.Services;
using Aplikacija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Aplikacija.Controllers
{
    [Route("api/customer")]
    public class CustomersController : Controller
    {
        private CustomersService _customersService;
        public CustomersController(CustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpPost("create-customer")]
        public IActionResult CreateCustomer([FromBody] CustomerVM customer)
        {
            _customersService.AddCustomer(customer);
            return Ok(customer);
        }
    }
}
