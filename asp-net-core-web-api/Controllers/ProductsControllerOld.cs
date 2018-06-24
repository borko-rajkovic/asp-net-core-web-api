using System.Collections.Generic;
using AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    //[Produces("application/json")]
    [Route("api/ProductsOld")]
    public class ProductsControllerOld : Controller
    {
        static List<Product> _products = new List<Product>()
        {
            new Product(){ProductId = 0, ProductName = "Laptop", ProductPrice = "200"},
            new Product(){ProductId = 1, ProductName = "SmartPhone", ProductPrice = "100"}
        };

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_products);
        }

        [HttpGet("LoadWelcomeMessage")]
        public IActionResult GetWelcomeMessage()
        {
            return Ok("Welcome");
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            _products[id] = product;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }
    }
}
