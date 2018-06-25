using System.Collections.Generic;
using AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/movies")]
    public class MoviesV1Controller : Controller
    {
        static List<MovieV1> _movies = new List<MovieV1>()
        {
            new MovieV1() {Id = 0, MovieName = "Mission Impossible"},
            new MovieV1() {Id = 1, MovieName = "Jumanji"},
        };

        // GET: api/MoviesV1
        [HttpGet]
        public IEnumerable<MovieV1> Get()
        {
            return _movies;
        }

        // GET: api/MoviesV1/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        
        // POST: api/MoviesV1
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/MoviesV1/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
