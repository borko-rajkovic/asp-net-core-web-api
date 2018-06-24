using System.Collections.Generic;
using AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        static List<Customer> _customer = new List<Customer>()
        {
            new Customer(){Id=0,Name="Andrew",Email="andrew@gmail.com",Phone="555"},
            new Customer(){Id=1,Name="Tom",Email="tom@gmail.com",Phone="555"}
        };

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customer;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customer.Add(customer);
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
