using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreWebApi.Data;
using AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private ProductsDbContext productsDbContext;

        public ProductsController(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get(string sortPrice, int? pageNumber, int? pageSize)
        {
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 1;

            IQueryable<Product> products = productsDbContext.Products;
            switch (sortPrice)
            {
                case "desc":
                    products = products.OrderByDescending(p => p.ProductPrice);
                    break;
                case "asc":
                    products = products.OrderBy(p => p.ProductPrice);
                    break;
            }

            var items = products.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToList();

            return items;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound("No record found");
            }

            return Ok(product);
        }
        
        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productsDbContext.Products.Add(product);
            productsDbContext.SaveChanges(true);

            return StatusCode(StatusCodes.Status201Created);
        }
        
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            try
            {
                productsDbContext.Products.Update(product);
                productsDbContext.SaveChanges(true);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return NotFound("No Record Found against this id");
            }

            return Ok("Product updated");

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound("No record found");
            }

            productsDbContext.Products.Remove(product);
            productsDbContext.SaveChanges(true);

            return Ok("Product Deleted");
        }
    }
}
